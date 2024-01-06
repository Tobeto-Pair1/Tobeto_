using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.UserSocials
{
    public class CreateUserSocialRequest
    {
        public Guid Id { get; set; }
        public Guid SocialMediaId { get; set; }
    }
}
