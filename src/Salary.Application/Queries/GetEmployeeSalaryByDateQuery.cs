using MediatR;
using Salary.Core.Entities;
using System;
using System.Collections.Generic;

namespace Salary.Application.Queries
{
    // EmployeeSalary GetEmployeeSalaryByBaseSalaryQuery with EmployeeSalary response
    public class GetEmployeeSalaryByDateQuery: IRequest<List<EmployeeSalary>>
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public GetEmployeeSalaryByDateQuery(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

    }
}
