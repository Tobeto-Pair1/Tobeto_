using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserSocials;

public class GetListUserSocialResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Link { get; set; }
    public string SocialMediaName { get; set; }
}
