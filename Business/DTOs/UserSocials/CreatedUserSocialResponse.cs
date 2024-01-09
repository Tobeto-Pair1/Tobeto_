namespace Business.DTOs.UserSocials;

public class CreatedUserSocialResponse
{
    public Guid UserId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Link { get; set; }
}
