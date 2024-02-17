using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concretes;

public class InstructorOperationClaim : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public Guid OperationClaimId { get; set; }

    public virtual Instructor Instructor { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

}
