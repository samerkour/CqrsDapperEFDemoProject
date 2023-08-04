using MediatR;
using Salary.Application.Commands;
using Salary.Application.Mapper;
using Salary.Application.Response;
using Salary.Core.Entities;
using Salary.Core.Repositories.Command;
using Salary.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Handlers.CommandHandler
{
    // EmployeeSalary edit command handler with employeeSalary response as output
    public class EditEmployeeSalaryHandler : IRequestHandler<EditEmployeeSalaryCommand, EmployeeSalaryResponse>
    {
        private readonly IEmployeeSalaryCommandRepository _employeeSalaryCommandRepository;
        private readonly IEmployeeSalaryQueryRepository _employeeSalaryQueryRepository;
        public EditEmployeeSalaryHandler(IEmployeeSalaryCommandRepository employeeSalaryRepository, IEmployeeSalaryQueryRepository employeeSalaryQueryRepository)
        {
            _employeeSalaryCommandRepository = employeeSalaryRepository;
            _employeeSalaryQueryRepository = employeeSalaryQueryRepository;
        }
        public async Task<EmployeeSalaryResponse> Handle(EditEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            var employeeSalaryEntity = EmployeeSalaryMapper.Mapper.Map<EmployeeSalary>(request);

            if (employeeSalaryEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _employeeSalaryCommandRepository.UpdateAsync(employeeSalaryEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedEmployeeSalary = await _employeeSalaryQueryRepository.GetByIdAsync(request.Id);
            var employeeSalaryResponse = EmployeeSalaryMapper.Mapper.Map<EmployeeSalaryResponse>(modifiedEmployeeSalary);

            return employeeSalaryResponse;
        }
    }
}
