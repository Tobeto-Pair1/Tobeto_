using Core.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ForeignLanguage: Entity<int>
    {
        
        public string Name { get; set; }
        public int LevelId { get; set; }
        
        public virtual ICollection<UserLanguage> UserLanguages{ get; set; }
        public virtual LanguageLevel LanguageLevel { get; set; }
    }
}
