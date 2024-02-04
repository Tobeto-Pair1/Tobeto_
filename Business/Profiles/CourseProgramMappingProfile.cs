using AutoMapper;
using Business.DTOs.CourseProgram;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
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

            CreateMap<CourseProgram, GetListCourseProgramResponse>().
                ForMember(destinationMember: a => a.CourseId,
            memberOptions: opt => opt.MapFrom(a => a.Course.Id)).
                ForMember(destinationMember: a => a.ProgramId,
            memberOptions: opt => opt.MapFrom(a => a.Program.Id))
                .ReverseMap();

            CreateMap<Paginate<CourseProgram>, Paginate<GetListCourseProgramResponse>>()
                .ReverseMap();
        }
    }
}
