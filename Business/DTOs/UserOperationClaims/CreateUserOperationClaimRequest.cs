namespace Business.Dtos.UserOperationClaims;

public class CreateUserOperationClaimRequest
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}