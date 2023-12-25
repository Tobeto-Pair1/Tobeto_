using AutoMapper;
using Business.DTOs.ForeignLanguages;
using Core.DataAccess.Dynamic;
using Entities.Concrete;

namespace Business.Profiles
{
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();
            CreateMap<CreateForeignLanguageRequest, ForeignLanguage>().ReverseMap();

            CreateMap<Paginate<ForeignLanguage>, GetListForeignLanguageResponse>().ReverseMap();
        }

    }
}
