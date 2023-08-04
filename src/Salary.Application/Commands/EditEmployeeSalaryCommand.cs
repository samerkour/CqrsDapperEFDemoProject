using MediatR;
using Salary.Application.Response;
using System;

namespace Salary.Application.Commands
{
    // EmployeeSalary create command with EmployeeSalaryResponse
    public class EditEmployeeSalaryCommand : IRequest<EmployeeSalaryResponse>
    {

        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 BaseSalary { get; set; }
        public Int64 Allowance { get; set; }
        public Int64 Transportation { get; set; }
        public string OverTimeCalculator { get; set; }
        public Int64 TotalSalary { get; set; }
    }
}
