using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

//Id = UserId
public class UserLanguage : Entity<Guid>
{                                                                           
    public Guid ForeignLanguageId { get; set; }
    public Guid LanguageLevelId { get; set; }

    public virtual User User { get; set; }
    public virtual ForeignLanguage ForeignLanguage { get; set; }
    public virtual LanguageLevel LanguageLevel { get; set; }
}
