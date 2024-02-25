using AutoMapper;
using Business.DTOs.Experiences;
using Core.DataAccess.Dynamic;
using Entities.Concrete;
using Entities.Concretes;

namespace Business.Profiles;

public class ExperienceMappingProfile : Profile
{
    public ExperienceMappingProfile()
    {
        CreateMap<Experience, CreatedExperienceResponse>().ReverseMap();
        CreateMap<Experience, CreateExperienceRequest>().ReverseMap();

        CreateMap<Experience, UpdatedExperienceResponse>().ReverseMap();
        CreateMap<Experience, UpdateExperienceRequest>().ReverseMap();

        CreateMap<Experience, DeletedExperienceResponse>().ReverseMap();
        CreateMap<Experience, DeleteExperienceRequest>().ReverseMap();

        CreateMap<Experience, GetListExperienceResponse>().ReverseMap();
        CreateMap<Paginate<Experience>, Paginate<GetListExperienceResponse>>().ReverseMap();
    }
}