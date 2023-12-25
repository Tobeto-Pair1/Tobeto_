using AutoMapper;
using Business.DTOs.Skills;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concrete;
using Entities.Concretes;

namespace Business.Profiles;

public class MappingSkillProfile : Profile
{
    public MappingSkillProfile()
    {
        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<CreateSkillRequest, Skill>().ReverseMap();

        CreateMap<Paginate<Skill>, GetListSkillResponse>().ReverseMap();
        CreateMap<Skill, GetListSkillResponse > ().ReverseMap();

        CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
        CreateMap<UpdateSkillRequest, Skill>().ReverseMap();

        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<CreateSkillRequest, Skill>().ReverseMap();

    }
}