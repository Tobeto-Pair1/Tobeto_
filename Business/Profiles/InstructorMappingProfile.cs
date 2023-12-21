using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();


        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();


        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();

        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();


        CreateMap<Instructor, GetListInstructorResponse>().
            ForMember(destinationMember: a => a.FullName,
            memberOptions: opt => opt.MapFrom(a => a.User.FirstName + a.User.Lastname)).ReverseMap();

        CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
    }

}