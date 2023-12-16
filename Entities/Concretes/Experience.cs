using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Experience : Entity<int>
{
    public int UserId { get; set; }
    public int PositionId { get; set;}
    public int SectorId { get; set;}
    public int CompanyId { get; set; }
    public int CityId { get; set; }
    public City City { get; set;} 
}
