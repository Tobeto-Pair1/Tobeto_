using AutoMapper;
using Business.DTOs.SynchronLessonInstructors;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SynchronLessonInstructorMappingProfile : Profile
    {
        public SynchronLessonInstructorMappingProfile()
        {
            CreateMap<SynchronLessonInstructor, CreatedSynchronLessonInstructorResponse>().ReverseMap();

            CreateMap<SynchronLessonInstructor, CreateSynchronLessonInstructorRequest>().ReverseMap();
            CreateMap<SynchronLessonInstructor, DeletedSynchronLessonInstructorResponse>().ReverseMap();

            CreateMap<SynchronLessonInstructor, DeleteSynchronLessonInstructorRequest>().ReverseMap();

            CreateMap<SynchronLessonInstructor, UpdatedSynchronLessonInstructorResponse>().ReverseMap();

            CreateMap<SynchronLessonInstructor, UpdateSynchronLessonInstructorRequest>().ReverseMap();

            CreateMap<SynchronLessonInstructor, GetListSynchronLessonInstructorResponse>().ReverseMap();

            CreateMap<Paginate<SynchronLessonInstructor>, Paginate<GetListSynchronLessonInstructorResponse>>().ReverseMap();
        }
    }
}
