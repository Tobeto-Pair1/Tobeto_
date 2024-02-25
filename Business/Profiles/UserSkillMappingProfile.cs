using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.UserSkills;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

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

        CreateMap<UserSkill, GetListUserSkillResponse>()
            .ForMember(s=>s.SkillName, opt=>opt.MapFrom(s=>s.Skill.Name))
            .ReverseMap();
        CreateMap<Paginate<UserSkill>, Paginate<GetListUserSkillResponse>>().ReverseMap();
    }
}
