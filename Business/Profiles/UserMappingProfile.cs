using AutoMapper;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
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
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<Address, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreateUserRequest>()
                //.IncludeMembers(memberExpressions: a => a.Address)
                .ReverseMap();

            CreateMap<User, DeletedUserResponse>().ReverseMap();
            CreateMap<User, DeleteUserRequest>().ReverseMap();

            CreateMap<User, UpdatedUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();

            CreateMap<User, GetListUserResponse>()
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
