using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class ForeignLanguageLevel : Entity<Guid>
{
    public string Name { get; set; }
    
    public virtual ICollection<UserLanguage> UserLanguages { get; set; }

}
