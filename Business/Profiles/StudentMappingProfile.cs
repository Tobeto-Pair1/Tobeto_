using AutoMapper;
using Business.DTOs.Students;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<Student, CreateStudentRequest>().ReverseMap();

        CreateMap<Student, GetListStudentResponse>()
             .ForMember(destinationMember: a => a.GetListUserResponse,
                memberOptions: opt => opt.MapFrom(a => a.User))
            .ReverseMap();
        CreateMap<Paginate<Student>, Paginate<GetListStudentResponse>>().ReverseMap();

        CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
        CreateMap<Student, UpdateStudentRequest>().ReverseMap();

        CreateMap<Student, DeletedStudentResponse>().ReverseMap();
        CreateMap<Student, DeleteStudentRequest>().ReverseMap();
    }
}