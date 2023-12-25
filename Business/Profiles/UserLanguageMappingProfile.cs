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
            ForMember(destinationMember: a => a.IdentityNumber,
            memberOptions: opt => opt.MapFrom(a => a.User.IdentityNumber)).
            ForMember(destinationMember: a => a.FirstName,
            memberOptions: opt => opt.MapFrom(a => a.User.FirstName)).
             ForMember(destinationMember: a => a.Lastname,
            memberOptions: opt => opt.MapFrom(a => a.User.Lastname)).
            ForMember(destinationMember: a => a.PhoneNumber,
            memberOptions: opt => opt.MapFrom(a => a.User.PhoneNumber)).
            ForMember(destinationMember: a => a.Email,
            memberOptions: opt => opt.MapFrom(a => a.User.Email)).
            ForMember(destinationMember: a => a.BirthDate,
            memberOptions: opt => opt.MapFrom(a => a.User.BirthDate)).
            ForMember(destinationMember: a => a.AboutMe,
            memberOptions: opt => opt.MapFrom(a => a.User.AboutMe)).ReverseMap();


            CreateMap<UserLanguage, CreateUserLanguageRequest>().
                  ForMember(destinationMember: a => a.LanguageName,
                memberOptions: opt => opt.MapFrom(a => a.ForeignLanguage.Name)).
                ForMember(destinationMember: a => a.LanguageLevelName,
                memberOptions: opt => opt.MapFrom(a => a.LanguageLevel.Name)).
                ForMember(destinationMember: a => a.IdentityNumber,
                memberOptions: opt => opt.MapFrom(a => a.User.IdentityNumber)).
                ForMember(destinationMember: a => a.FirstName,
                memberOptions: opt => opt.MapFrom(a => a.User.FirstName)).
                 ForMember(destinationMember: a => a.Lastname,
                memberOptions: opt => opt.MapFrom(a => a.User.Lastname)).
                ForMember(destinationMember: a => a.PhoneNumber,
                memberOptions: opt => opt.MapFrom(a => a.User.PhoneNumber)).
                ForMember(destinationMember: a => a.Email,
                memberOptions: opt => opt.MapFrom(a => a.User.Email)).
                ForMember(destinationMember: a => a.BirthDate,
                memberOptions: opt => opt.MapFrom(a => a.User.BirthDate)).
                ForMember(destinationMember: a => a.AboutMe,
                memberOptions: opt => opt.MapFrom(a => a.User.AboutMe))
                .ReverseMap();

            CreateMap<UserLanguage, DeletedUserLanguageResponse>().ReverseMap();
            CreateMap<DeleteUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<UserLanguage, UpdatedUserLanguageResponse>().ReverseMap();
            CreateMap<UpdateUserLanguageRequest, UserLanguage>().ReverseMap();

            CreateMap<Paginate<UserLanguage>, GetListUserLanguageResponse>().ReverseMap();
            CreateMap<UserLanguage, GetListUserLanguageResponse>().ReverseMap();
        }
    }
}
/*ForMember(destinationMember: a => a.CityName,
            memberOptions: opt => opt.MapFrom(a => a.User.Address.City.Name)).
            ForMember(destinationMember: a => a.CountryName,
            memberOptions: opt => opt.MapFrom(a => a.User.Address.Country.Name)).
            ForMember(destinationMember: a => a.TownName,
            memberOptions: opt => opt.MapFrom(a => a.User.Address.Town.Name))*/