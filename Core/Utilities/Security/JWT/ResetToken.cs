using Core.Entities;

namespace Core.Utilities.Security.JWT;

public class ResetToken : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime? Revoked { get; set; }
}