using AutoMapper;
using Business.DTOs.Course;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {

            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();


            CreateMap<Course, UpdateCourseRequest>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();


            CreateMap<Course, DeleteCourseRequest>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();


            CreateMap<Course, GetListCourseResponse>()
                .ForMember(destinationMember: a => a.CourseTypeId,
            memberOptions: opt => opt.MapFrom(a => a.CourseType.Id))
                .ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();
        }
    }
}
