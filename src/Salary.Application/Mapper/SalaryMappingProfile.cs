using AutoMapper;
using Salary.Application.Commands;
using Salary.Application.Response;
using Salary.Core.Entities;

namespace Salary.Application.Mapper
{
    public class SalaryMappingProfile : Profile
    {
        public SalaryMappingProfile()
        {
            CreateMap<EmployeeSalary, EmployeeSalaryResponse>().ReverseMap();
            CreateMap<EmployeeSalary, CreateEmployeeSalaryCommand>().ReverseMap();
            CreateMap<EmployeeSalary, EditEmployeeSalaryCommand>().ReverseMap();
        }
    }
}
