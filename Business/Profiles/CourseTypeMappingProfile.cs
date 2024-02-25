using AutoMapper;
using Business.DTOs.CourseType;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

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



        CreateMap<CourseType, GetListCourseTypeResponse>().ReverseMap();

        CreateMap<Paginate<CourseType>, Paginate<GetListCourseTypeResponse>>().ReverseMap();
    }
}


