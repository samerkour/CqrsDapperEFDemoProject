using MediatR;
using Salary.Application.Commands;
using Salary.Application.Mapper;
using Salary.Application.Response;
using Salary.Core.Entities;
using Salary.Core.Repositories.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Handlers.CommandHandler
{
    // EmployeeSalary create command handler with EmployeeSalaryResponse as output
    public class CreateEmployeeSalaryHandler : IRequestHandler<CreateEmployeeSalaryCommand, EmployeeSalaryResponse>
    {
        private readonly IEmployeeSalaryCommandRepository _employeeSalaryCommandRepository;
        public CreateEmployeeSalaryHandler(IEmployeeSalaryCommandRepository employeeSalaryCommandRepository)
        {
            _employeeSalaryCommandRepository = employeeSalaryCommandRepository;
        }
        public async Task<EmployeeSalaryResponse> Handle(CreateEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            var employeeSalaryEntity = EmployeeSalaryMapper.Mapper.Map<EmployeeSalary>(request);

            if(employeeSalaryEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newEmployeeSalary = await _employeeSalaryCommandRepository.AddAsync(employeeSalaryEntity);
            var employeeSalaryResponse = EmployeeSalaryMapper.Mapper.Map<EmployeeSalaryResponse>(newEmployeeSalary);
            return employeeSalaryResponse;
        }
    }
}
