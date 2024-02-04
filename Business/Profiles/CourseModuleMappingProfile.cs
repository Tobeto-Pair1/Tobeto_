using AutoMapper;
using Business.DTOs.CourseModule;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseModuleMappingProfile:Profile
    {
        public CourseModuleMappingProfile()
        {
            CreateMap<CourseModule, CreateCourseModuleRequest>().ReverseMap();
            CreateMap<CourseModule, CreatedCourseModuleResponse>().ReverseMap();


            CreateMap<CourseModule, UpdateCourseModuleRequest>().ReverseMap();
            CreateMap<CourseModule, UpdatedCourseModuleResponse>().ReverseMap();


            CreateMap<CourseModule, DeleteCourseModuleRequest>().ReverseMap();
            CreateMap<CourseModule, DeletedCourseModuleResponse>().ReverseMap();


            CreateMap<CourseModule, GetListCourseModuleResponse>()
                .ForMember(destinationMember: a => a.CourseId,
            memberOptions: opt => opt.MapFrom(a => a.Course.Id))
                .ReverseMap();
            CreateMap<Paginate<CourseModule>, Paginate<GetListCourseModuleResponse>>().ReverseMap();
        }
    }
}
