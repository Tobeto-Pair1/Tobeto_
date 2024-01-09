using AutoMapper;
using Business.DTOs.ForeignLanguages;
using Core.DataAccess.Dynamic;
using Entities.Concrete;

namespace Business.Profiles;

public class ForeignLanguageMappingProfile : Profile
{
    public ForeignLanguageMappingProfile()
    {
        CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, CreateForeignLanguageRequest>().ReverseMap();

        CreateMap<ForeignLanguage, DeletedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, DeleteForeignLanguageRequest>().ReverseMap();

        CreateMap<ForeignLanguage, UpdatedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, UpdateForeignLanguageRequest>().ReverseMap();

        CreateMap<Paginate<ForeignLanguage>, Paginate<GetListForeignLanguageResponse>>().ReverseMap();
        CreateMap<Paginate<ForeignLanguage>, GetListForeignLanguageResponse>().ReverseMap();
    }

}