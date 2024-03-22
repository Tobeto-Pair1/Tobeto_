using Core.Utilities.Security.JWT;


namespace Business.Dtos.RefreshTokens;

public class RefreshTokenResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
