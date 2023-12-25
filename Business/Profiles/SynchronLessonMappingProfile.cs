using AutoMapper;
using Business.DTOs.SynchronLessons;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SynchronLessonMappingProfile:Profile
    {
        public SynchronLessonMappingProfile()
        {
            CreateMap<SynchronLesson, CreatedSynchronLessonResponse>().ReverseMap();

            CreateMap<SynchronLesson, CreateSynchronLessonRequest>().ReverseMap();
            CreateMap<SynchronLesson, DeletedSynchronLessonResponse>().ReverseMap();

            CreateMap<SynchronLesson, DeleteSynchronLessonRequest>().ReverseMap();

            CreateMap<SynchronLesson, UpdatedSynchronLessonResponse>().ReverseMap();

            CreateMap<SynchronLesson, UpdateSynchronLessonRequest>().ReverseMap();

            CreateMap<SynchronLesson, GetListSynchronLessonResponse>().ReverseMap();

            CreateMap<Paginate<SynchronLesson>, Paginate<GetListSynchronLessonResponse>>().ReverseMap();

        }
    }
}
