using AutoMapper;
using Business.Dtos.ResetTokens;
using Core.Utilities.Security.JWT;

namespace Business.Profiles;

public class ResetTokenProfile : Profile
{
    public ResetTokenProfile()
    {
        CreateMap<ResetToken, RevokedTokenResponse>().ReverseMap();
    }
}
