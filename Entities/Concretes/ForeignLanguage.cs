using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ForeignLanguage: Entity<int>
    {
        public int LanguageId { get; set; }
        public int UserId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }
}
