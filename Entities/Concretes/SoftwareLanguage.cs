using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class SoftwareLanguage : Entity<int>
{


    public string Name { get; set; }

    public ICollection<SoftwareLanguage> SoftwareLanguages { get; set; }
}
