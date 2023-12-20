using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserLanguageMappingProfile:Profile
    {
        public UserLanguageMappingProfile()
        {
            CreateMap<UserLanguage, CreatedUserLanguageResponse>().ReverseMap();
            CreateMap<CreateUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<UserLanguage, GetListUserLanguageResponse>().ReverseMap();
        }
    }
}
