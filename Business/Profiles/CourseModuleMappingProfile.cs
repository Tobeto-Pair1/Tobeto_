using AutoMapper;
using Business.DTOs.CourseModule;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

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
            .ForMember(a=>a.CourseName, opt=>opt.MapFrom(a=>a.Course.Name)).ReverseMap();
        CreateMap<Paginate<CourseModule>, Paginate<GetListCourseModuleResponse>>().ReverseMap();
    }
}
