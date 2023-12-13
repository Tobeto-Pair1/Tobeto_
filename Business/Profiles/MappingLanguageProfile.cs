using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Entities.Concrete;

namespace Business.Profiles
{
    public class MappingLanguageProfile : Profile
    {
        public MappingLanguageProfile()
        {
            CreateMap<ForeignLanguage, CreatedLanguageResponse>().ReverseMap();
            CreateMap<CreateLanguageRequest, ForeignLanguage>().ReverseMap();

            CreateMap<ForeignLanguage, GetListLanguageResponse>().ReverseMap();
        }

    }
}
