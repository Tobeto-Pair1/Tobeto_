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
    public Guid UserId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }

    public virtual User User { get; set; }
    public virtual ForeignLanguage ForeignLanguage { get; set; }
    public virtual ForeignLanguageLevel ForeignLanguageLevel { get; set; }
}
