

namespace Business.Dtos.UserOperationClaims;

public class GetListUserOperationClaimResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public required string? ClaimName { get; set; }
}
