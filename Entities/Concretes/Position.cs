using Core.Entities;

namespace Entities.Concretes;

public class Position : Entity<Guid>
{
    public string Name { get; set;}


    //public virtual ICollection<Experience> Experiences { get; set; }


}
