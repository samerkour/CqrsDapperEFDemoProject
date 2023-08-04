using MediatR;
using Salary.Application.Commands;
using Salary.Core.Repositories.Command;
using Salary.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Handlers.CommandHandler
{
    // EmployeeSalary delete command handler with string response as output
    public class DeleteEmployeeSalaryHandler : IRequestHandler<DeleteEmployeeSalaryCommand, String>
    {
        private readonly IEmployeeSalaryCommandRepository _employeeSalaryCommandRepository;
        private readonly IEmployeeSalaryQueryRepository _employeeSalaryQueryRepository;
        public DeleteEmployeeSalaryHandler(IEmployeeSalaryCommandRepository employeeSalaryRepository, IEmployeeSalaryQueryRepository employeeSalaryQueryRepository)
        {
            _employeeSalaryCommandRepository = employeeSalaryRepository;
            _employeeSalaryQueryRepository = employeeSalaryQueryRepository;
        }

        public async Task<string> Handle(DeleteEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeSalaryEntity = await _employeeSalaryQueryRepository.GetByIdAsync(request.Id);

                await _employeeSalaryCommandRepository.DeleteAsync(employeeSalaryEntity);
            }
            catch(Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "EmployeeSalary information has been deleted!";
        }
    }
}
