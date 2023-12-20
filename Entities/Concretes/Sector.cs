using Core.Entities;

namespace Entities.Concretes;

public class Sector:Entity<int>
{
    public string Name { get; set;}

    public virtual ICollection<Experience> Experiences { get; set; }
}
