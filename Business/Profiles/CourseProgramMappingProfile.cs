using AutoMapper;
using Business.DTOs.CourseProgram;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class CourseProgramMappingProfile:Profile
{
    public CourseProgramMappingProfile()
    {
        CreateMap<CourseProgram, CreatedCourseProgramResponse>().ReverseMap();
        CreateMap<CourseProgram, CreateCourseProgramRequest>().ReverseMap();

        CreateMap<CourseProgram, DeletedCourseProgramResponse>().ReverseMap();
        CreateMap<CourseProgram, DeleteCourseProgramRequest>().ReverseMap();

        CreateMap<CourseProgram, UpdateCourseProgramRequest>().ReverseMap();
        CreateMap<CourseProgram, UpdatedCourseProgramResponse>().ReverseMap();

        CreateMap<CourseProgram, GetListCourseProgramResponse>().ReverseMap();

        CreateMap<Paginate<CourseProgram>, Paginate<GetListCourseProgramResponse>>().ReverseMap();
    }
}
