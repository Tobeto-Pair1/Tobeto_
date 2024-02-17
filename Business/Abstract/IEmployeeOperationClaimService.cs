using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IEmployeeOperationClaimService
{
    Task<IList<OperationClaim>> GetClaims(Guid id);

}