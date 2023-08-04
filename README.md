# CqrsDapperEFDemoProject

# CQRS-Entity Framework- Dapper- Clean Architecture-SampleProject


This is a open-source project written in .NET Core 6.0

This sample project demonistrate the most common technologies used to develop large scale and distrebusted software systems (Microservices).
 
The sample project implements the below model to simulate CRUD Actions:

```
EmployeeSalaries {
	Firstname
	Lastname
	BaseSalary
	Allowance
	Transportation
    CreatedDate
    ModifiedDate
    OverTimeCalculator
    TotalSalary
}
```

## Technologies and Architecture used:

- .Net Core 6.0
- Entity Framework Core 6.0
- Dapper
- .NET Core Native DI
- AutoMapper
- MediatR
- Swagger UI
- Unit Test
# 
- Clean architecture
- Responsibility separation concerns
- SOLID Principles and Clean Code
- CQRS (Dapper for Queries , EF for Commands)

## Installation

Create SQL server database (e.g. EmployeeDb)
Create table using EmployeeSalaries.sql file
Change connection string in Salary.API Project


