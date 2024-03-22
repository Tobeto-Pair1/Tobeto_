namespace Business.Dtos.RefreshTokens;

public class RevokedTokenResponse
{
    public Guid Id { get; set; }
    public string Token { get; set; }
}