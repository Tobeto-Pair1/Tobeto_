namespace Business.DTOs.UserSocials;

public class UpdateUserSocialRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Link { get; set; }
}
