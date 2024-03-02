using Core.Entities;

namespace Entities.Concretes;

public class Town : Entity<Guid>
{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public virtual City  City { get; set; }
}
