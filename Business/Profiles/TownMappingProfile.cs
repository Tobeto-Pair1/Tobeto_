using AutoMapper;
using Business.DTOs.Towns;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class TownMappingProfile:Profile
{
    public TownMappingProfile()
    {

        CreateMap<Town, CreatedTownResponse>().ReverseMap();
        CreateMap<Town, CreateTownRequest>().ReverseMap();

        CreateMap<Town, DeletedTownResponse>().ReverseMap();
        CreateMap<Town, DeleteTownRequest>().ReverseMap();

        CreateMap<Town, UpdatedTownResponse>().ReverseMap();
        CreateMap<Town, UpdateTownRequest>().ReverseMap();

        CreateMap<Town, GetListTownResponse>().ReverseMap();
        CreateMap<Paginate<Town>, Paginate<GetListTownResponse>>().ReverseMap();
    }
}
