using AutoMapper;
using Business.DTOs.LessonLanguages;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonLanguageMappingProfile : Profile
{
    public LessonLanguageMappingProfile()
    {
        
        CreateMap<LessonLanguage, CreateLessonLanguageRequest>().ReverseMap();
        CreateMap<LessonLanguage, CreatedLessonLanguageResponse>().ReverseMap();


        CreateMap<LessonLanguage, UpdateLessonLanguageRequest>().ReverseMap();
        CreateMap<LessonLanguage, UpdatedLessonLanguageResponse>().ReverseMap();


        CreateMap<LessonLanguage, DeleteLessonLanguageRequest>().ReverseMap();
        CreateMap<LessonLanguage, DeletedLessonLanguageResponse>().ReverseMap();


        CreateMap<LessonLanguage, GetListLessonLanguageResponse>().ReverseMap();
        CreateMap<Paginate<LessonLanguage>, Paginate<GetListLessonLanguageResponse>>().ReverseMap();
    }
}