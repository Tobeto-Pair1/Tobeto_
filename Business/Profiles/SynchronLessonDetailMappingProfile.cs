using AutoMapper;
using Business.DTOs.SynchronLessonDetails;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class SynchronLessonDetailMappingProfile : Profile
{
    public SynchronLessonDetailMappingProfile()
    {
        CreateMap<SynchronLessonDetail, CreatedSynchronLessonDetailResponse>().ReverseMap();

        CreateMap<SynchronLessonDetail, CreateSynchronLessonDetailRequest>().ReverseMap();
        CreateMap<SynchronLessonDetail, DeletedSynchronLessonDetailResponse>().ReverseMap();

        CreateMap<SynchronLessonDetail, DeleteSynchronLessonDetailRequest>().ReverseMap();

        CreateMap<SynchronLessonDetail, UpdatedSynchronLessonDetailResponse>().ReverseMap();

        CreateMap<SynchronLessonDetail, UpdateSynchronLessonDetailRequest>().ReverseMap();

        CreateMap<SynchronLessonDetail, GetListSynchronLessonDetailResponse>()
            .ForMember(destinationMember: a => a.CategoryName, memberOptions: opt => opt.MapFrom(a => a.Category.Name))
            .ForMember(destinationMember: a => a.CourseModuleName, memberOptions: opt => opt.MapFrom(a => a.CourseModule.Name))
            .ForMember(destinationMember: a => a.LessonLanguageName, memberOptions: opt => opt.MapFrom(a => a.LessonLanguage.Name))
            .ForMember(destinationMember: a => a.SubTypeName, memberOptions: opt => opt.MapFrom(a => a.SubType.Name))
            .ReverseMap();

        CreateMap<Paginate<SynchronLessonDetail>, Paginate<GetListSynchronLessonDetailResponse>>().ReverseMap();
    }
}
