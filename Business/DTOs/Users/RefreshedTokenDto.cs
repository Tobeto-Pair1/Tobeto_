using Core.Utilities.Security.JWT;


namespace Business.DTOs.Users;

public class RefreshedTokenDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
}
