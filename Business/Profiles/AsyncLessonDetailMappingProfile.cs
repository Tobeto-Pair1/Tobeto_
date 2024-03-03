using AutoMapper;
using Business.DTOs.AsyncLessonDetail;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class AsyncLessonDetailDetailMappingProfile : Profile
{
    public AsyncLessonDetailDetailMappingProfile()
    {

        CreateMap<AsyncLessonDetail, CreatedAsyncLessonDetailResponse>().ReverseMap();
        CreateMap<AsyncLessonDetail, CreateAsyncLessonDetailRequest>().ReverseMap();

        CreateMap<AsyncLessonDetail, UpdatedAsyncLessonDetailResponse>()
            .ReverseMap();
        CreateMap<AsyncLessonDetail, UpdateAsyncLessonDetailRequest>().ReverseMap();

        CreateMap<AsyncLessonDetail, DeleteAsyncLessonDetailRequest>().ReverseMap();
        CreateMap<AsyncLessonDetail, DeletedAsyncLessonDetailResponse>().ReverseMap();

        CreateMap<AsyncLessonDetail, GetListAsyncLessonDetailResponse>()
              .ForMember(destinationMember: a => a.ManufacturerName,
       memberOptions: opt => opt.MapFrom(a => a.Manufacturer.Name))
            .ForMember(destinationMember: a => a.CategoryName,
       memberOptions: opt => opt.MapFrom(a => a.Category.Name))
            .ForMember(destinationMember: a => a.AsyncLessonName,
       memberOptions: opt => opt.MapFrom(a => a.AsyncLesson.Name))
            .ForMember(destinationMember: a => a.LessonLanguageName,
       memberOptions: opt => opt.MapFrom(a => a.LessonLanguage.Name))
            .ForMember(destinationMember: a => a.SubTypeName,
       memberOptions: opt => opt.MapFrom(a => a.SubType.Name))
            .ReverseMap();
        CreateMap<Paginate<AsyncLessonDetail>, Paginate<GetListAsyncLessonDetailResponse>>().ReverseMap();
    }
}
