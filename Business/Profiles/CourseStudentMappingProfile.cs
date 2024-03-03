using AutoMapper;
using Business.DTOs.CourseStudent;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class CourseStudentMappingProfile : Profile
{
    public CourseStudentMappingProfile()
    {

        CreateMap<CourseStudent, CreateCourseStudentRequest>().ReverseMap();
        CreateMap<CourseStudent, CreatedCourseStudentResponse>().ReverseMap();

        CreateMap<CourseStudent, UpdateCourseStudentRequest>().ReverseMap();
        CreateMap<CourseStudent, UpdatedCourseStudentResponse>().ReverseMap();

        CreateMap<CourseStudent, DeleteCourseStudentRequest>().ReverseMap();
        CreateMap<CourseStudent, DeletedCourseStudentResponse>().ReverseMap();

        CreateMap<CourseStudent, GetListCourseStudentResponse>().ReverseMap();
        CreateMap<Paginate<CourseStudent>, Paginate<GetListCourseStudentResponse>>().ReverseMap();
    }
}
