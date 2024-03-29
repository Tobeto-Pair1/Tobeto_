namespace Business.DTOs.Users;

public class UpdateResetPasswordRequest
{
    public Guid Id { get; set; }
    public string ResetToken { get; set; }
    public string NewPassword { get; set; }
    public string CheckNewPassword { get; set; }
}   