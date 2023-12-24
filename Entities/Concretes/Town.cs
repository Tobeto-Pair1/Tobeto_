using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Town : Entity<Guid>

{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public virtual City  City { get; set; }
}
