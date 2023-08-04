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
    // Get specific employeeSalary query handler with EmployeeSalary response as output
    public class GetEmployeeSalaryByDateHandler : IRequestHandler<GetEmployeeSalaryByDateQuery, List<EmployeeSalary>>
    {
        private readonly IEmployeeSalaryQueryRepository _employeeSalaryQueryRepository;

        public GetEmployeeSalaryByDateHandler(IEmployeeSalaryQueryRepository employeeSalaryQueryRepository)
        {
            _employeeSalaryQueryRepository = employeeSalaryQueryRepository;
        }
        public async Task<List<EmployeeSalary>> Handle(GetEmployeeSalaryByDateQuery request, CancellationToken cancellationToken)
        {
            var employeeSalarys = (List<EmployeeSalary>)await _employeeSalaryQueryRepository.GetEmployeeSalaryByDate(request.From, request.To);
            return employeeSalarys;
        }
    }
}
