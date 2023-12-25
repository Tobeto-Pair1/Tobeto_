using AutoMapper;
using Business.DTOs.AboutOfCourses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class AboutOfCourseMappingProfile : Profile
{
    public AboutOfCourseMappingProfile()
    {
        CreateMap<AboutOfCourse, CreatedAboutOfCourseResponse>().
            ForMember(destinationMember: a => a.CourseName,
            memberOptions: opt => opt.MapFrom(a => a.Course.Name)).
            ForMember(destinationMember: a => a.CategoryName,
            memberOptions: opt => opt.MapFrom(a => a.Category.Name)).
            ForMember(destinationMember: a => a.ManufacturerName,
            memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Name)).ReverseMap();

        CreateMap<AboutOfCourse, CreateAboutOfCourseRequest>().
            ForMember(destinationMember: a => a.CourseName,
            memberOptions: opt => opt.MapFrom(a => a.Course.Name)).
            ForMember(destinationMember: a => a.CategoryName,
            memberOptions: opt => opt.MapFrom(a => a.Category.Name)).
            ForMember(destinationMember: a => a.ManufacturerName,
            memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Name)).ReverseMap();


        CreateMap<AboutOfCourse, DeletedAboutOfCourseResponse>().ReverseMap();

        CreateMap<AboutOfCourse, DeleteAboutOfCourseRequest>().ReverseMap();


        CreateMap<AboutOfCourse, UpdateAboutOfCourseRequest>().ReverseMap();

        CreateMap<AboutOfCourse, UpdatedAboutOfCourseResponse>().ReverseMap();


        CreateMap<AboutOfCourse, GetListAboutOfCourseResponse>().
            ForMember(destinationMember: a => a.CourseName,
            memberOptions: opt => opt.MapFrom(a => a.Course.Name)).
            ForMember(destinationMember: a => a.CourseId,
            memberOptions: opt => opt.MapFrom(a => a.Category.Id)).
            ForMember(destinationMember: a => a.CategoryId,
            memberOptions: opt => opt.MapFrom(a => a.Category.Id)).
            ForMember(destinationMember: a => a.ManufacturerId,
            memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Id)).
            ForMember(destinationMember: a => a.CategoryName,
            memberOptions: opt => opt.MapFrom(a => a.Category.Name)).
            ForMember(destinationMember: a => a.ManufacturerName,
            memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Name)).ReverseMap();

        CreateMap<Paginate<AboutOfCourse>, Paginate<GetListAboutOfCourseResponse>>().ReverseMap();
    }

}
