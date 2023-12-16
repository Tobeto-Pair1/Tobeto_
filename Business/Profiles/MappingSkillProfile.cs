using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class MappingSkillProfile : Profile
{
    public MappingSkillProfile()
    {
        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<CreateSkillRequest, Skill>().ReverseMap();

        CreateMap<Skill, GetListSkillResponse>().ReverseMap();
        CreateMap<PageRequest, Skill>().ReverseMap();//

        CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
        CreateMap<UpdateSkillRequest, Skill>().ReverseMap();

        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<CreateSkillRequest, Skill>().ReverseMap();

    }
}