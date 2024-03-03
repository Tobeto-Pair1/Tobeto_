using AutoMapper;
using Business.DTOs.Instructors;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using Entities.Concretes;

namespace Business.Profiles;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<Instructor, UserAuth>().ReverseMap();


        CreateMap<UserAuth, InstructorForLoginRequest>().ReverseMap();
        CreateMap<UserAuth, CreateInstructorRequest>().ReverseMap();
        CreateMap<UserAuth, CreatedInstructorResponse>().ReverseMap();


        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, InstructorForLoginRequest>().ReverseMap();
        CreateMap<Employee, InstructorForRegisterRequest>().ReverseMap();
        CreateMap<CreateInstructorRequest, InstructorForRegisterRequest>().ReverseMap();



        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();


        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();


        CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();

        CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
    }

}