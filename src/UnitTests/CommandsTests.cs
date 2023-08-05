using Moq;
using Salary.Application.Commands;
using Salary.Application.Handlers.CommandHandler;
using Salary.Application.Handlers.QueryHandlers;
using Salary.Application.Mapper;
using Salary.Application.Queries;
using Salary.Application.Response;
using Salary.Core.Entities;
using Salary.Core.Repositories.Command;
using Salary.Core.Repositories.Query;
using Salary.Infrastructure.Repository.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class CommandsTests
    {
        private readonly Mock<IEmployeeSalaryCommandRepository> _mockEmployeeSalaryCommandRepo;
        private readonly Mock<IEmployeeSalaryQueryRepository> _mockEmployeeSalaryQueryRepo;


        public CommandsTests() 
        {
            _mockEmployeeSalaryCommandRepo = new Mock<IEmployeeSalaryCommandRepository>();
            _mockEmployeeSalaryQueryRepo = new Mock<IEmployeeSalaryQueryRepository>();
        }


        [Fact]
        public async Task CreateEmployeeSalary_ValidObjectPassed_ReturnedEmployeeSalaryResponseItem()  
        {
            // Arrange
            var employeeSalary = new EmployeeSalary { Id = 1,
                FirstName = "Samer",
                LastName = "Kour",
                BaseSalary = 1,
                Allowance = 2,
                Transportation = 3,
                OverTimeCalculator = "CaleculatorA",
                TotalSalary = 6
            };

            _mockEmployeeSalaryCommandRepo.Setup(r => r.AddAsync(It.IsAny<EmployeeSalary>())).ReturnsAsync(employeeSalary);

            var command = EmployeeSalaryMapper.Mapper.Map<CreateEmployeeSalaryCommand>(employeeSalary);

            var handler = new CreateEmployeeSalaryHandler(_mockEmployeeSalaryCommandRepo.Object);
          
            // Act
            var result = await handler.Handle(command, default);

            // Assert
            _mockEmployeeSalaryCommandRepo.Verify(x => x.AddAsync(It.IsAny<EmployeeSalary>()), Times.Once);
        }


        [Fact]
        public async Task EditEmployeeSalary_ValidObjectPassed_ReturnedEmployeeSalaryResponseItem()
        {
            // Arrange
            var employeeSalary = new EmployeeSalary
            {
                Id = 1,
                FirstName = "Samer",
                LastName = "Kour",
                BaseSalary = 1,
                Allowance = 2,
                Transportation = 3,
                OverTimeCalculator = "CaleculatorA",
                TotalSalary = 6
            };

            _mockEmployeeSalaryCommandRepo.Setup(r => r.UpdateAsync(It.IsAny<EmployeeSalary>())).Returns(Task.CompletedTask);

            _mockEmployeeSalaryQueryRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(employeeSalary);


            var command = EmployeeSalaryMapper.Mapper.Map<EditEmployeeSalaryCommand>(employeeSalary);

            var handler = new EditEmployeeSalaryHandler(_mockEmployeeSalaryCommandRepo.Object, _mockEmployeeSalaryQueryRepo.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            _mockEmployeeSalaryCommandRepo.Verify(x => x.UpdateAsync(It.IsAny<EmployeeSalary>()), Times.Once);
        }




        [Fact]
        public async Task DeleteEmployeeSalary_ValidObjectPassed_ReturnedEmployeeSalaryDeleteResponse() 
        {
            // Arrange
            var employeeSalary = new EmployeeSalary
            {
                Id = 1,
                FirstName = "Samer",
                LastName = "Kour",
                BaseSalary = 1,
                Allowance = 2,
                Transportation = 3,
                OverTimeCalculator = "CaleculatorA",
                TotalSalary = 6
            };

            _mockEmployeeSalaryQueryRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(employeeSalary);
            _mockEmployeeSalaryCommandRepo.Setup(r => r.DeleteAsync(It.IsAny<EmployeeSalary>())).Returns(Task.CompletedTask);

 


            var command = new DeleteEmployeeSalaryCommand(1);

            var handler = new DeleteEmployeeSalaryHandler(_mockEmployeeSalaryCommandRepo.Object, _mockEmployeeSalaryQueryRepo.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            _mockEmployeeSalaryCommandRepo.Verify(x => x.DeleteAsync(It.IsAny<EmployeeSalary>()), Times.Once);
        }




    }
}
