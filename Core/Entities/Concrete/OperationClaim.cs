namespace Core.Entities.Concrete;

public class OperationClaim : Entity<Guid>
{
    public string Name { get; set; }
   public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
