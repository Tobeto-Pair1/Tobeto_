using Core.Entities;

namespace Entities.Concretes;

public class Company : Entity<Guid>
{
    public string Name { get; set; }

    public Guid ExperienceId { get; set; }
   public virtual ICollection <Experience> Experiences { get; set; }

    
}