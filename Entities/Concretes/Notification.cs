using Core.Entities;

namespace Entities.Concretes;

public class Notification : Entity<Guid> 
{
    public string Title { get; set; }
    public string Label { get; set; }
}
