using AutoMapper;
using Business.DTOs.Employees;
using Business.DTOs.Instructors;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using Entities.Concretes;

namespace Business.Profiles;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<Instructor, UserAuth>()
          // .ForMember(destinationMember: u => u.Id, memberOptions: opt => opt.MapFrom(e => e.User.Id))
          //.ForMember(destinationMember: u => u.FirstName, memberOptions: opt => opt.MapFrom(e => e.User.FirstName))
          //.ForMember(destinationMember: u => u.LastName, memberOptions: opt => opt.MapFrom(e => e.User.LastName))
          //.ForMember(destinationMember: u => u.Email, memberOptions: opt => opt.MapFrom(e => e.User.Email))
          //.ForMember(destinationMember: u => u.PhoneNumber, memberOptions: opt => opt.MapFrom(e => e.User.PhoneNumber))
          //.ForMember(destinationMember: u => u.PasswordSalt, memberOptions: opt => opt.MapFrom(e => e.User.PasswordSalt))
          //.ForMember(destinationMember: u => u.PasswordHash, memberOptions: opt => opt.MapFrom(e => e.User.PasswordHash))
          .ReverseMap();


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


        CreateMap<Instructor, GetListInstructorResponse>()
            /*.ForMember(destinationMember: a => a.FullName,
            memberOptions: opt => opt.MapFrom(a => a.User.FirstName + a.User.Lastname))*/
            .ReverseMap();

        CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
    }

}