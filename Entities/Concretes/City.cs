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

    public Country Country { get; set; }
    public Address Address { get; set; }
}
