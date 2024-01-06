using AutoMapper;
using Business.DTOs.Skills;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concrete;
using Entities.Concretes;

namespace Business.Profiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<Skill, CreateSkillRequest>().ReverseMap();

        CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
        CreateMap<Skill, UpdateSkillRequest>().ReverseMap();

        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<Skill, CreateSkillRequest>().ReverseMap();

        CreateMap<Skill, GetListSkillResponse>().ReverseMap();
        CreateMap<Paginate<Skill>, Paginate<GetListSkillResponse>>().ReverseMap();
        

    }
}