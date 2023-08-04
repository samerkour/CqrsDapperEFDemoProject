using Moq;
using Salary.Application.Handlers.QueryHandlers;
using Salary.Application.Queries;
using Salary.Application.Response;
using Salary.Core.Entities;
using Salary.Core.Repositories.Query;

namespace UnitTests
{
    public class QueriesTests
    {
        private readonly Mock<IEmployeeSalaryQueryRepository> _mockRepo;

    
        public QueriesTests()
        {
            _mockRepo = new Mock<IEmployeeSalaryQueryRepository>();
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems()
        {
            //Arrange 
            _mockRepo.Setup( repo => repo.GetAllAsync())
                .ReturnsAsync(new List<EmployeeSalary> { new EmployeeSalary() });

            var handler = new GetAllEmployeeSalaryHandler(_mockRepo.Object);

            // Act

            var result = await handler.Handle(new GetAllEmployeeSalaryQuery(), default);

            // Assert
            Assert.NotEmpty(result);
        }



        [Theory]
        [InlineData(0)]
        public async void GetById_UnknownIdPassed_ReturnsNoContentResult(long id)  
        {
            //Arrange 
            _mockRepo.Setup(repo => repo.GetAllAsync())
             .ReturnsAsync(new List<EmployeeSalary> { new EmployeeSalary() { 
                Id=1,
                FirstName = "Samer",
                LastName = "Kour",
                BaseSalary = 1,
                Allowance = 2,
                Transportation = 3,
                OverTimeCalculator = "CaleculatorA",
                TotalSalary = 6  } 
             });

            var handler = new GetEmployeeSalaryByIdHandler(_mockRepo.Object);

            // Act

            var result = await handler.Handle(new GetEmployeeSalaryByIdQuery(id), default);

            // Assert
            Assert.Null(result);
        }


        [Theory]
        [InlineData(1)]
        public async void GetById_ExistingIdPassed_ReturnsOkRightItem(long id)
        {
            //Arrange 
            _mockRepo.Setup(repo => repo.GetByIdAsync(id))
               .ReturnsAsync( new EmployeeSalary() { 
                    Id=1,
                    FirstName = "Samer",
                    LastName = "Kour",
                    BaseSalary = 1,
                    Allowance = 2,
                    Transportation = 3,
                    OverTimeCalculator = "CaleculatorA",
                    TotalSalary = 6  
               });

            var handler = new GetEmployeeSalaryByIdHandler(_mockRepo.Object);

            // Act

            var result = await handler.Handle(new GetEmployeeSalaryByIdQuery(id), default);

            // Assert
            Assert.Equal(id,result.Id);
        }


        [Fact]
        public async Task GetRange_ExistingDatePassed_ReturnsRangeItems() 
        {
            //Arrange 
            _mockRepo.Setup(repo => repo.GetEmployeeSalaryByDate(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1)))
              .ReturnsAsync(new List<EmployeeSalary> { new EmployeeSalary() {
                    Id=1,
                    FirstName = "Samer",
                    LastName = "Kour",
                    BaseSalary = 1,
                    Allowance = 2,
                    Transportation = 3,
                    OverTimeCalculator = "CaleculatorA",
                    TotalSalary = 6  }
              });

            var handler = new GetEmployeeSalaryByDateHandler(_mockRepo.Object);

            // Act

            var result = await handler.Handle(new GetEmployeeSalaryByDateQuery(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1)), default);

            // Assert
            Assert.NotEmpty(result);
        }



    }
}