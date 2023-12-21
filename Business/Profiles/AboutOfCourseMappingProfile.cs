using AutoMapper;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class AboutOfCourseMappingProfile : Profile
{
    public AboutOfCourseMappingProfile()
    {
        CreateMap<AboutOfCourse, CreatedAboutOfCourseResponse>().ReverseMap();

        CreateMap<AboutOfCourse, CreateAboutOfCourseRequest>().ReverseMap();


        CreateMap<AboutOfCourse, DeletedAboutOfCourseResponse>().ReverseMap();

        CreateMap<AboutOfCourse, DeleteAboutOfCourseRequest>().ReverseMap();


        CreateMap<AboutOfCourse, UpdateAboutOfCourseRequest>().ReverseMap();

        CreateMap<AboutOfCourse, UpdatedAboutOfCourseResponse>().ReverseMap();


        CreateMap<AboutOfCourse, GetListAboutOfCourseResponse>().
            ForMember(destinationMember: a => a.CategoryName,
            memberOptions: opt => opt.MapFrom(a => a.Category.Name)).
            ForMember(destinationMember: a => a.ManufacturerName,
            memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Name)).ReverseMap();

        CreateMap<Paginate<AboutOfCourse>, Paginate<GetListAboutOfCourseResponse>>().ReverseMap();
    }

}
