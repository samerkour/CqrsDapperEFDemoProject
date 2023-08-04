using Salary.Core.Entities;
using Salary.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salary.Core.Repositories.Query
{
    // Interface for EmployeeSalaryQueryRepository
    public interface IEmployeeSalaryQueryRepository : IQueryRepository<EmployeeSalary>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<EmployeeSalary>> GetAllAsync();
        Task<EmployeeSalary> GetByIdAsync(Int64 id);
        Task<IEnumerable<EmployeeSalary>> GetEmployeeSalaryByDate(DateTime from, DateTime to);
    }
}
