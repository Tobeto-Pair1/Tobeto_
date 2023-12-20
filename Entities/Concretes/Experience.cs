using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Experience : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid PositionId { get; set;}
    public Guid SectorId { get; set;}
    public Guid CompanyId { get; set; }
    public Guid CityId { get; set; }


    public virtual City City { get; set;} 
    public virtual Company Company { get; set; }
    public virtual Position Position { get; set; }
    public virtual Sector Sector { get; set; }
    public virtual User User { get; set; }
}
