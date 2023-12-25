using AutoMapper;
using Business.DTOs.Employees;
using Core.DataAccess.Dynamic;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, CreatedEmployeeResponse>().ReverseMap();
            CreateMap<CreateEmployeeRequest, Employee>().ReverseMap();

            CreateMap<Employee, DeletedEmployeeResponse>().ReverseMap();
            CreateMap<DeleteEmployeeRequest, Employee>().ReverseMap();

            CreateMap<Employee, UpdatedEmployeeResponse>().ReverseMap();
            CreateMap<UpdateEmployeeRequest, Employee>().ReverseMap();

            CreateMap<Paginate<Employee>, Paginate<GetListEmployeeResponse>>().ReverseMap();
            CreateMap<Employee, GetListEmployeeResponse>()
           .ForMember(destinationMember: a => a.DepartmentId,
            memberOptions: opt => opt.MapFrom(a => a.Department.Id))
           .ForMember(destinationMember: a => a.UserId,
            memberOptions: opt => opt.MapFrom(a => a.User.Id))
           .ForMember(destinationMember: a => a.FullName,
            memberOptions: opt => opt.MapFrom(a => (a.User.FirstName )))
           .ReverseMap();
        }
    }
}