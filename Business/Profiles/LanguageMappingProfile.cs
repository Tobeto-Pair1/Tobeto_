using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concrete;

namespace Business.Profiles
{
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<ForeignLanguage, CreatedLanguageResponse>().ReverseMap();
            CreateMap<CreateLanguageRequest, ForeignLanguage>().ReverseMap();

            CreateMap<Paginate<ForeignLanguage>, GetListLanguageResponse>().ReverseMap();
        }

    }
}
