using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<CreateStudentRequest, Student>().ReverseMap();

        CreateMap<Student, GetListStudentResponse>().ReverseMap();
        CreateMap<PageRequest, Student>().ReverseMap();//

        CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
        CreateMap<UpdateStudentRequest, Student>().ReverseMap();

        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<CreateStudentRequest, Student>().ReverseMap();
    }
}