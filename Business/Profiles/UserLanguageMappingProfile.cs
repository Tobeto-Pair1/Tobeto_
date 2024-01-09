using AutoMapper;
using Business.DTOs.UserLanguages;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserLanguageMappingProfile : Profile
    {
        public UserLanguageMappingProfile()
        {
            CreateMap<UserLanguage, CreatedUserLanguageResponse>().ReverseMap();
            CreateMap<UserLanguage, CreateUserLanguageRequest>().ReverseMap();

            CreateMap<UserLanguage, DeletedUserLanguageResponse>().ReverseMap();
            CreateMap<DeleteUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<UserLanguage, UpdatedUserLanguageResponse>().ReverseMap();
            CreateMap<UpdateUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<Paginate<UserLanguage>, Paginate<GetListUserLanguageResponse>>().ReverseMap();

            CreateMap<UserLanguage, GetListUserLanguageResponse>()
                 .ForMember(destinationMember: a => a.ForeignLanguageName,
                 memberOptions: opt => opt.MapFrom(a => a.ForeignLanguage.Name)).
                ForMember(destinationMember: a => a.ForeignLanguageLevelName,
                memberOptions: opt => opt.MapFrom(a => a.ForeignLanguageLevel.Name))
                .ReverseMap();
        }
    }
}
