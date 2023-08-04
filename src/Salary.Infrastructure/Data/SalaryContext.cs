using Microsoft.EntityFrameworkCore;
using Salary.Core.Entities;

namespace Salary.Infrastructure.Data
{
    // Context class for command
    public class SalaryContext : DbContext
    {
        public SalaryContext(DbContextOptions<SalaryContext> options) : base (options)
        {

        }

        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
    }
}
