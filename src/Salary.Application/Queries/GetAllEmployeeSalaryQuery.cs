using MediatR;
using Salary.Core.Entities;
using System.Collections.Generic;

namespace Salary.Application.Queries
{
    // EmployeeSalary query with List<EmployeeSalary> response
    public record GetAllEmployeeSalaryQuery : IRequest<List<EmployeeSalary>>
    {

    }
}
