using MediatR;
using Salary.Application.Queries;
using Salary.Core.Entities;
using Salary.Core.Repositories.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Handlers.QueryHandlers
{
    // Get all employeeSalary query handler with List<EmployeeSalary> response as output
    public class GetAllEmployeeSalaryHandler : IRequestHandler<GetAllEmployeeSalaryQuery, List<EmployeeSalary>>
    {
        private readonly IEmployeeSalaryQueryRepository _employeeSalaryQueryRepository;

        public GetAllEmployeeSalaryHandler(IEmployeeSalaryQueryRepository employeeSalaryQueryRepository)
        {
            _employeeSalaryQueryRepository = employeeSalaryQueryRepository;
        }
        public async Task<List<EmployeeSalary>> Handle(GetAllEmployeeSalaryQuery request, CancellationToken cancellationToken)
        {
            return (List<EmployeeSalary>)await _employeeSalaryQueryRepository.GetAllAsync();
        }
    }
}
