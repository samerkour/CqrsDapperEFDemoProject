using MediatR;
using System;

namespace Salary.Application.Commands
{
    // EmployeeSalary create command with string response
    public class DeleteEmployeeSalaryCommand : IRequest<String>
    {
        public Int64 Id { get; private set; }

        public DeleteEmployeeSalaryCommand(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
