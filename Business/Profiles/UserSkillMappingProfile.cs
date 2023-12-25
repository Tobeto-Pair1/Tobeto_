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
            CreateMap<CreateUserSkillRequest, UserSkill>().ReverseMap();

            CreateMap<UserSkill, DeletedUserSkillResponse>().ReverseMap();
            CreateMap<DeleteUserSkillRequest, UserSkill>().ReverseMap();
            CreateMap<UserSkill, UpdatedUserSkillResponse>().ReverseMap();
            CreateMap<UpdateUserSkillRequest, UserSkill>().ReverseMap();

            CreateMap<UserSkill, GetListUserSkillResponse>().ReverseMap();
            CreateMap<Paginate<UserSkill>, Paginate<GetListUserSkillResponse>>().ReverseMap();
        }
    }
}
