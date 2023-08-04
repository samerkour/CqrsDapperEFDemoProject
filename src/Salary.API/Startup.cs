using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Salary.Application.Handlers.CommandHandler;
using Salary.Core.Repositories.Command.Base;
using Salary.Core.Repositories.Query;
using Salary.Core.Repositories.Query.Base;
using Salary.Infrastructure.Data;
using Salary.Infrastructure.Repository.Command;
using Salary.Infrastructure.Repository.Command.Base;
using Salary.Infrastructure.Repository.Query;
using Salary.Infrastructure.Repository.Query.Base;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Salary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            bool isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() ==
                              "production";

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD")))
            {
                var builder = new SqlConnectionStringBuilder(connectionString)
                {
                    Password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD")
                };
                Console.WriteLine(builder.ConnectionString);
                connectionString = builder.ConnectionString;
            }


            services.AddDbContextPool<SalaryContext>(options =>
                {
                    if (!isProduction)
                    {
                        options.EnableSensitiveDataLogging();
                    }
                    options.UseSqlServer(connectionString);
                }
            );



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Salary.API", Version = "v1" });
                c.SchemaFilter<EnumSchemaFilter>(); 
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Register dependencies
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateEmployeeSalaryHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IEmployeeSalaryQueryRepository, EmployeeSalaryQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<Core.Repositories.Command.IEmployeeSalaryCommandRepository, EmployeeSalaryCommandRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Salary.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(name: "EmployeeSalary",
                //    pattern: "{id?}/{controller=EmployeeSalary}/{action=ImportEmployeeSalary}",
                //    defaults: new { controller = "EmployeeSalary", action = "ImportEmployeeSalary" }
                //    );

                //endpoints.MapDefaultControllerRoute();

            });
        }
    }

    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name => schema.Enum.Add(new OpenApiString($"{name}")));
            }
        }
    }
}
