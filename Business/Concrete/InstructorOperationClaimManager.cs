using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Business.Concrete;

public class InstructorOperationClaimManager : IInstructorOperationClaimService
{
    private readonly IInstructorOperationClaimDal _instructorOperationClaimDal;

    public InstructorOperationClaimManager(IInstructorOperationClaimDal instructorOperationClaimDal)
    {
        _instructorOperationClaimDal = instructorOperationClaimDal;
    }

    public async Task<IList<OperationClaim>> GetClaims(Guid id)
    {
        var userOperationClaims = await _instructorOperationClaimDal.GetListAsync(u => u.InstructorId == id,
                                                               include: u => u.Include(u => u.OperationClaim));
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
            { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
        return operationClaims;
    }
}
