using AutoMapper;
using Business.Dtos.RefreshTokens;
using Core.Utilities.Security.JWT;

namespace Business.Profiles;

public class RefreshTokenProfile : Profile
{
    public RefreshTokenProfile()
    {
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
    }
}
