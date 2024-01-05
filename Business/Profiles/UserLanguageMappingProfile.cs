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
            CreateMap<UserLanguage, CreatedUserLanguageResponse>().
            ForMember(destinationMember: a => a.LanguageName,
            memberOptions: opt => opt.MapFrom(a => a.ForeignLanguage.Name)).
            ForMember(destinationMember: a => a.LanguageLevelName,
            memberOptions: opt => opt.MapFrom(a => a.LanguageLevel.Name)).
          ReverseMap();


            CreateMap<UserLanguage, CreateUserLanguageRequest>().
                  ForMember(destinationMember: a => a.LanguageName,
                memberOptions: opt => opt.MapFrom(a => a.ForeignLanguage.Name)).
                ForMember(destinationMember: a => a.LanguageLevelName,
                memberOptions: opt => opt.MapFrom(a => a.LanguageLevel.Name)).
                ReverseMap();

            CreateMap<UserLanguage, DeletedUserLanguageResponse>().ReverseMap();
            CreateMap<DeleteUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<UserLanguage, UpdatedUserLanguageResponse>().ReverseMap();
            CreateMap<UpdateUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<Paginate<UserLanguage>, GetListUserLanguageResponse>().ReverseMap();
            CreateMap<UserLanguage, GetListUserLanguageResponse>().ReverseMap();
        }
    }
}
