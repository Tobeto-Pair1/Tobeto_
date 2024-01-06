using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.UserSkills;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserSkillMappingProfile : Profile
    {
        public UserSkillMappingProfile()
        {
            CreateMap<UserSkill, CreatedUserSkillResponse>().ReverseMap();
            CreateMap<UserSkill, CreateUserSkillRequest>().ReverseMap();

            CreateMap<UserSkill, DeletedUserSkillResponse>().ReverseMap();
            CreateMap<UserSkill, DeleteUserSkillRequest>().ReverseMap();

            CreateMap<UserSkill, UpdatedUserSkillResponse>().ReverseMap();
            CreateMap<UserSkill, UpdateUserSkillRequest>().ReverseMap();

            CreateMap<UserSkill, GetListUserSkillResponse>().ReverseMap();
            CreateMap<Paginate<UserSkill>, Paginate<GetListUserSkillResponse>>().ReverseMap();
        }
    }
}
