using AutoMapper;
using Business.DTOs.Company;
using Business.DTOs.CourseType;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;
public class CourseTypeMappingProfile : Profile
{

    public CourseTypeMappingProfile()
    {
        CreateMap<CourseType, CreatedCourseTypeResponse>().ReverseMap();

        CreateMap<CourseType, CreateCourseTypeRequest>().ReverseMap();

        CreateMap<CourseType, DeletedCourseTypeResponse>().ReverseMap();

        CreateMap<CourseType, DeleteCourseTypeRequest>().ReverseMap();

        CreateMap<CourseType, UpdateCourseTypeRequest>().ReverseMap();

        CreateMap<CourseType, UpdatedCourseTypeResponse>().ReverseMap();
      
    }
}


