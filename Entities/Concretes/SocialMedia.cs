using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class SocialMedia : Entity<Guid>
{

    public string Name { get; set; }
    public string Link { get; set; }

    public virtual ICollection<UserSocial> UserSocials { get; set; }
}
