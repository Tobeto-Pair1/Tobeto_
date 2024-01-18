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
        CreateMap<Experience, CreatedExperienceResponse>()
            //.ForMember(destinationMember: a => a.CompanyName,
            //memberOptions: opt => opt.MapFrom(a => a.Company.Name))
            //.ForMember(destinationMember: a => a.PositionName,
            //memberOptions: opt => opt.MapFrom(a => a.Position.Name))
            //.ForMember(destinationMember: a => a.SectorName,
            //memberOptions: opt => opt.MapFrom(a => a.Sector.Name))
            //.ForMember(destinationMember: a => a.CityId,
            //memberOptions: opt => opt.MapFrom(a => a.City.Id))

            .ReverseMap();

        CreateMap<Experience, CreateExperienceRequest>()
            //.ForMember(destinationMember: a => a.CompanyName,
            //memberOptions: opt => opt.MapFrom(a => a.Company.Name))
            //.ForMember(destinationMember: a => a.PositionName,
            //memberOptions: opt => opt.MapFrom(a => a.Position.Name))
            //.ForMember(destinationMember: a => a.SectorName,
            //memberOptions: opt => opt.MapFrom(a => a.Sector.Name))
            //.ForMember(destinationMember: a => a.CityName,
            //memberOptions: opt => opt.MapFrom(a => a.City.Name))
            //.ForMember(destinationMember: a => a.CountryName,
            //memberOptions: opt => opt.MapFrom(a => a.City.Country.Name))
            .ReverseMap();



        CreateMap<Experience, UpdatedExperienceResponse>().ReverseMap();
        CreateMap<Experience, UpdateExperienceRequest>().ReverseMap();

        CreateMap<Experience, DeletedExperienceResponse>().ReverseMap();
        CreateMap<Experience, DeleteExperienceRequest>().ReverseMap();


        CreateMap<Experience, GetListExperienceResponse>()
            //.ForMember(destinationMember: a => a.CompanyName,
            //memberOptions: opt => opt.MapFrom(a => a.Company.Name))
            //.ForMember(destinationMember: a => a.PositionName,
            //memberOptions: opt => opt.MapFrom(a => a.Position.Name))
            //.ForMember(destinationMember: a => a.SectorName,
            //memberOptions: opt => opt.MapFrom(a => a.Sector.Name))
            //.ForMember(destinationMember: a => a.CityName,
            //memberOptions: opt => opt.MapFrom(a => a.City.Name))
            //.ForMember(destinationMember: a => a.CountryName,
            //memberOptions: opt => opt.MapFrom(a => a.City.Country.Name))
            .ReverseMap();

        CreateMap<Paginate<Experience>, Paginate<GetListExperienceResponse>>().ReverseMap();

    }

}