using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concrete;

namespace Business.Profiles
{
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<ForeignLanguage, CreatedLanguageResponse>().ReverseMap();
            CreateMap<CreateLanguageRequest, ForeignLanguage>().ReverseMap();

            CreateMap<ForeignLanguage, GetListLanguageResponse>().ReverseMap();
        }

    }
}
