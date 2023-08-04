using Salary.Core.Entities;
using Salary.Core.Repositories.Command.Base;

namespace Salary.Core.Repositories.Command
{
    // Interface for employeeSalary command repository
    public interface IEmployeeSalaryCommandRepository : ICommandRepository<EmployeeSalary>
    {

    }
}
