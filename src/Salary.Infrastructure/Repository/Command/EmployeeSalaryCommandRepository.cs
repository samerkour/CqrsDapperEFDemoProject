using Salary.Core.Entities;
using Salary.Core.Repositories.Command;
using Salary.Infrastructure.Data;
using Salary.Infrastructure.Repository.Command.Base;

namespace Salary.Infrastructure.Repository.Command
{
    // Command Repository class for employeeSalary
    public class EmployeeSalaryCommandRepository : CommandRepository<EmployeeSalary>, IEmployeeSalaryCommandRepository
    {
        public EmployeeSalaryCommandRepository(SalaryContext context) : base(context)
        {

        }
    }
}
