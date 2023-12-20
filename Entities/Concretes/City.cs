using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class City : Entity<Guid> 
{

    public Guid CountryId { get; set; }

    public string Name { get; set; }

    public virtual Country Country { get; set; } 
    public virtual List<Town> Town { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; }


    public Address Address { get; set; }
}

   

