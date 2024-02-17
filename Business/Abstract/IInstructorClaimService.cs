using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IInstructorOperationClaimService
{
    Task<IList<OperationClaim>> GetClaims(Guid id);

}
