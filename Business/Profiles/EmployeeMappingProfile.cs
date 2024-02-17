using AutoMapper;
using Business.DTOs.Employees;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {

                CreateMap<Employee, UserAuth>().ReverseMap();

        CreateMap<Employee, CreatedEmployeeResponse>()
            .ForMember(e => e.DepartmentName, opt => opt.MapFrom(e => e.Department.Name))
            .ReverseMap();
        CreateMap<Employee, CreateEmployeeRequest>()
            .ForMember(e => e.DepartmentName, opt => opt.MapFrom(e => e.Department.Name))
            .ReverseMap();

        CreateMap<Employee, EmployeeForRegisterRequest>()
            .ForMember(e => e.DepartmentName, opt => opt.MapFrom(e => e.Department.Name))
            .ReverseMap();
        CreateMap<CreateEmployeeRequest, EmployeeForRegisterRequest>()
          
           .ReverseMap();
        CreateMap<Employee, EmployeeForLoginRequest>().ReverseMap();

        CreateMap<Employee, DeletedEmployeeResponse>().ReverseMap();
        CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();

        CreateMap<Employee, UpdatedEmployeeResponse>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();

        CreateMap<Paginate<Employee>, Paginate<GetListEmployeeResponse>>().ReverseMap();
        CreateMap<Employee, GetListEmployeeResponse>()
            .ForMember(e => e.DepartmentName, opt => opt.MapFrom(e => e.Department.Name))
            .ReverseMap();
    }
}
