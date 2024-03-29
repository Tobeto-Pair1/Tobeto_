using Core.Utilities.Security.JWT;


namespace Business.Dtos.ResetTokens;

public class ResetTokenResponse
{
    public AccessToken AccessToken { get; set; }
    public ResetToken ResetToken { get; set; }
}
