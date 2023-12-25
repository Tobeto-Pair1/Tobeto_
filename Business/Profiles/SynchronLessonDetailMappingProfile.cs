using AutoMapper;
using Business.DTOs.SynchronLessonDetails;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SynchronLessonDetailMappingProfile: Profile
    {
        public SynchronLessonDetailMappingProfile()
        {
            CreateMap<SynchronLessonDetail, CreatedSynchronLessonDetailResponse>().ReverseMap();

            CreateMap<SynchronLessonDetail, CreateSynchronLessonDetailRequest>().ReverseMap();
            CreateMap<SynchronLessonDetail, DeletedSynchronLessonDetailResponse>().ReverseMap();

            CreateMap<SynchronLessonDetail, DeleteSynchronLessonDetailRequest>().ReverseMap();

            CreateMap<SynchronLessonDetail, UpdatedSynchronLessonDetailResponse>().ReverseMap();

            CreateMap<SynchronLessonDetail, UpdateSynchronLessonDetailRequest>().ReverseMap();

            CreateMap<SynchronLessonDetail, GetListSynchronLessonDetailResponse>().ReverseMap();

            CreateMap<Paginate<SynchronLessonDetail>, Paginate<GetListSynchronLessonDetailResponse>>().ReverseMap();
        }
    }
}
