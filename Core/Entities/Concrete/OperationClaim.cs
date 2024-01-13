namespace Core.Entities.Concrete;

public class OperationClaim : Entity<int>
{
    public string Name { get; set; }
   public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
