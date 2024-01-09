namespace Business.DTOs.UserSocials;

public class UpdatedUserSocialResponse
{
    public Guid UserId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Link { get; set; }
}
