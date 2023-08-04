using System;

namespace Salary.Application.Response
{
    // EmployeeSalary response or DTO class
    public class EmployeeSalaryResponse
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
