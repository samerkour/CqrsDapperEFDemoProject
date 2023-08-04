using MediatR;
using Salary.Application.Response;
using System;

namespace Salary.Application.Commands
{
    // EmployeeSalary create command with EmployeeSalaryResponse
    public class CreateEmployeeSalaryCommand : BaseCreateEmployeeSalaryCommand, IRequest<EmployeeSalaryResponse>
    {
        public string OverTimeCalculator { get; set; }
        public Int64 TotalSalary { get; set; }

        public CreateEmployeeSalaryCommand()
        {
            this.CreatedDate = DateTime.Now;
        }
    }

    public class BaseCreateEmployeeSalaryCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 BaseSalary { get; set; }
        public Int64 Allowance { get; set; }
        public Int64 Transportation { get; set; }
        public DateTime CreatedDate { get; set; }
     
    }

}
