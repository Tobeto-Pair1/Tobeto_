namespace Business.DTOs.Auths;

public class VerifyResetTokenRequest
{
    public string ResetToken { get; set; }
    public Guid UserId { get; set; }
}
