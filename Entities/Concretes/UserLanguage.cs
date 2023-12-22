using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class UserLanguage : Entity<Guid>
{
    public Guid ForeignLanguageId { get; set; }
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ForeignLanguage ForeignLanguage { get; set; }




}
