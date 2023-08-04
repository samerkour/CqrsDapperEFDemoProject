using Salary.Core.Entities.Base;
using System;

namespace Salary.Core.Entities
{
    // EmployeeSalary entity 
    public class EmployeeSalary : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 BaseSalary { get; set; }
        public Int64 Allowance { get; set; }
        public Int64 Transportation { get; set; }
        public string OverTimeCalculator { get; set; }
        public Int64 TotalSalary { get; set; }
    }
}
