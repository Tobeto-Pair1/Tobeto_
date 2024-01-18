namespace Business.DTOs.UserSocials;

public class DeletedUserSocialResponse
{
    public Guid UserId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Link { get; set; }
}
