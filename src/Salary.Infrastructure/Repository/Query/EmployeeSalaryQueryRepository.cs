using Dapper;
using Microsoft.Extensions.Configuration;
using Salary.Core.Entities;
using Salary.Core.Repositories.Query;
using Salary.Infrastructure.Repository.Query.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Salary.Infrastructure.Repository.Query
{
    // QueryRepository class for employeeSalary
    public class EmployeeSalaryQueryRepository : QueryRepository<EmployeeSalary>, IEmployeeSalaryQueryRepository
    {
        public EmployeeSalaryQueryRepository(IConfiguration configuration) 
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<EmployeeSalary>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM EmployeeSalaries";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<EmployeeSalary>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<EmployeeSalary> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM EmployeeSalaries WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<EmployeeSalary>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<IEnumerable<EmployeeSalary>> GetEmployeeSalaryByDate(DateTime from, DateTime to)
        {
            try
            {
                var query = "SELECT * FROM EmployeeSalaries WHERE CreatedDate BETWEEN @DateFrom AND @DateTo";
                var parameters = new DynamicParameters();
                parameters.Add("DateFrom", from, DbType.DateTime2);
                parameters.Add("DateTo", to, DbType.DateTime2);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<EmployeeSalary>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
