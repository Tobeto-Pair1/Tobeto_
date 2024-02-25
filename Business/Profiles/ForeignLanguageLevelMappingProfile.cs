using AutoMapper;
using Business.DTOs.ForeignLanguageLevels;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class ForeignLanguageLevelMappingProfile : Profile
{
    public ForeignLanguageLevelMappingProfile()
    {
        CreateMap<ForeignLanguageLevel, CreatedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, CreateForeignLanguageLevelRequest>().ReverseMap();

        CreateMap<ForeignLanguageLevel, DeletedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, DeleteForeignLanguageLevelRequest>().ReverseMap();

        CreateMap<ForeignLanguageLevel, UpdatedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, UpdateForeignLanguageLevelRequest>().ReverseMap();

        CreateMap<Paginate<ForeignLanguageLevel>, Paginate<GetListForeignLanguageLevelResponse>>().ReverseMap();
        CreateMap<ForeignLanguageLevel, GetListForeignLanguageLevelResponse>().ReverseMap();
    }

}