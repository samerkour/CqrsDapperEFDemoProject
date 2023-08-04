using Moq;
using Salary.Application.Commands;
using Salary.Application.Handlers.CommandHandler;
using Salary.Application.Handlers.QueryHandlers;
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
        private readonly Mock<IEmployeeSalaryCommandRepository> _mockRepo;


        public CommandsTests() 
        {
            _mockRepo = new Mock<IEmployeeSalaryCommandRepository>();
        }


        [Fact]
        public async Task CreateEmployeeSalary_ValidObjectPassed_ReturnedEmployeeSalaryResponseItem()  
        {
            // Arrange
            //_mockRepo.Setup(repo => repo.AddAsync(new EmployeeSalary()))
            //    .ReturnsAsync(new EmployeeSalary());

            var command = new CreateEmployeeSalaryCommand()
            {
                FirstName = "Samer",
                LastName = "Kour",
                BaseSalary = 1,
                Allowance = 2,
                Transportation = 3,
                OverTimeCalculator = "CaleculatorA",
                TotalSalary = 6
            };

            var handler = new CreateEmployeeSalaryHandler(_mockRepo.Object);
          
            // Act
            var result = await handler.Handle(command, default);

            // Assert
            _mockRepo.Verify(x => x.AddAsync(It.Is<EmployeeSalary>(e => e.Id == result.Id)), Times.Once);
        }

    }
}
