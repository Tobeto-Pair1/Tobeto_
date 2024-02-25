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
    public Guid CityId { get; set; }
    public string CompanyName { get; set; }
    public string PositionName { get; set; }
    public string SectorName { get; set; }
    public string Description { get; set; }
    public DateTime JobStart { get; set; }
    public DateTime JobCompletion { get; set; }


    public virtual User User { get; set; }
    public virtual City City { get; set; }
}
