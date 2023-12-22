using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
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
            CreateMap<Employee, GetListEmployeeResponse>().ReverseMap();
        }
    }
}
