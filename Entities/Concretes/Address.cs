using Core.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Address : Entity<int>
{
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int TownId { get; set; }
    public string Description { get; set; }

    public Country Country { get; set; }
    public City City { get; set; }
    public Town Town { get; set; }
    public User User { get; set; }
}
