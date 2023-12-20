using Core.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Address : Entity<Guid>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
    public string? Description { get; set; }

    public virtual Country Country { get; set; } 
    public virtual City City { get; set; } 
    public virtual Town Town { get; set; } 

    public  virtual User User { get; set; }





}
