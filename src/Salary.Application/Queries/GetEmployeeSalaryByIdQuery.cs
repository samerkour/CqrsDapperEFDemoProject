using MediatR;
using Salary.Core.Entities;
using System;

namespace Salary.Application.Queries
{
    // EmployeeSalary GetEmployeeSalaryByIdQuery with EmployeeSalary response
    public class GetEmployeeSalaryByIdQuery: IRequest<EmployeeSalary>
    {
        public Int64 Id { get; private set; }
        
        public GetEmployeeSalaryByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}
