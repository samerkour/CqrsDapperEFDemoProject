using AutoMapper;
using System;

namespace Salary.Application.Mapper
{
    public class EmployeeSalaryMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(()=>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<SalaryMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
