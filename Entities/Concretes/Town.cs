using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Town : Entity<int>

{
    public int CityId { get; set; }
    public string Name { get; set; }
    public City  City { get; set; }

  

}
