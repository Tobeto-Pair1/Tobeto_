using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class SocialMediaMappingProfile : Profile
{
    public SocialMediaMappingProfile()
    {
        CreateMap<SocialMedia, CreatedSocialMediaResponse>().ReverseMap();
        CreateMap<SocialMedia, CreateSocialMediaRequest>().ReverseMap();

        CreateMap<SocialMedia, DeletedSocialMediaResponse>().ReverseMap();
        CreateMap<SocialMedia, DeleteSocialMediaRequest>().ReverseMap();

        CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
        CreateMap<Paginate<SocialMedia>, Paginate<GetListSocialMediaResponse>>().ReverseMap();
    }
}