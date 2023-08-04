using MediatR;
using Salary.Application.Queries;
using Salary.Core.Entities;
using Salary.Core.Repositories.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Handlers.QueryHandlers
{
    // Get specific query handler with EmployeeSalary response as output
    public class GetEmployeeSalaryByIdHandler : IRequestHandler<GetEmployeeSalaryByIdQuery, EmployeeSalary>
    {
        private readonly IEmployeeSalaryQueryRepository _employeeSalaryQueryRepository;

        public GetEmployeeSalaryByIdHandler(IEmployeeSalaryQueryRepository employeeSalaryQueryRepository)
        {
            _employeeSalaryQueryRepository = employeeSalaryQueryRepository;
        }
        public async Task<EmployeeSalary> Handle(GetEmployeeSalaryByIdQuery request, CancellationToken cancellationToken)
        {
            var selectedEmployeeSalary = await _employeeSalaryQueryRepository.GetByIdAsync(request.Id);
            return selectedEmployeeSalary;
        }
    }
}
