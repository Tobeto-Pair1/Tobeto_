using AutoMapper;
using Business.DTOs.Auths;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserAuth>().ReverseMap();

            CreateMap<User, UpdatePasswordRequest>().ReverseMap();

            CreateMap<User, UpdateResetPasswordRequest>().ReverseMap();

            CreateMap<User, UserForRegisterRequest>().ReverseMap();
            CreateMap<User, UserForLoginRequest>().ReverseMap();

            CreateMap<UserAuth, UserForRegisterRequest>().ReverseMap();
            CreateMap<UserAuth, UserForLoginRequest>().ReverseMap();

            CreateMap<User, DeletedUserResponse>().ReverseMap();
            CreateMap<User, DeleteUserRequest>().ReverseMap();

            CreateMap<User, UpdatedUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserRequest>()
                  .ForMember(destinationMember: a => a.TownId,
           memberOptions: opt => opt.MapFrom(a => a.Address.TownId))
                .ForMember(destinationMember: a => a.CountryId,
           memberOptions: opt => opt.MapFrom(a => a.Address.CountryId))
                .ForMember(destinationMember: a => a.CityId,
           memberOptions: opt => opt.MapFrom(a => a.Address.CityId))
                .ForMember(destinationMember: a => a.Description,
           memberOptions: opt => opt.MapFrom(a => a.Address.Description))
                .ReverseMap();

            CreateMap<User, GetListUserResponse>()
                  .ForMember(destinationMember: a => a.TownId,
           memberOptions: opt => opt.MapFrom(a => a.Address.TownId))
                .ForMember(destinationMember: a => a.CountryId,
           memberOptions: opt => opt.MapFrom(a => a.Address.CountryId))
                .ForMember(destinationMember: a => a.CityId,
           memberOptions: opt => opt.MapFrom(a => a.Address.CityId))
                .ForMember(destinationMember: a => a.Description,
           memberOptions: opt => opt.MapFrom(a => a.Address.Description))
                .ForMember(destinationMember: a => a.TownName,
           memberOptions: opt => opt.MapFrom(a => a.Address.Town.Name))
                .ForMember(destinationMember: a => a.CountryName,
           memberOptions: opt => opt.MapFrom(a => a.Address.Country.Name))
                .ForMember(destinationMember: a => a.CityName,
           memberOptions: opt => opt.MapFrom(a => a.Address.City.Name))
                .ForMember(destinationMember: a => a.Description,
           memberOptions: opt => opt.MapFrom(a => a.Address.Description))
                .ReverseMap();
            CreateMap<Paginate<User>,Paginate<GetListUserResponse>>().ReverseMap();
        }
    }
}
