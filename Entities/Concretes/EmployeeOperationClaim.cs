using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class EmployeeOperationClaim : Entity<Guid>
{
    public Guid EmployeeId { get; set; }
    public Guid OperationClaimId { get; set; }

    public virtual Employee Employee { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

}
