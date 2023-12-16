using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class City : Entity<int>
{

    public int CountryId { get; set; }

    public string Name { get; set; }

    public Town Town { get; set; }
    public List<Country> Countries { get; set; }
    public List<Address>  Addresses { get; set; }
}
