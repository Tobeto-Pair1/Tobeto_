using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Business.Concrete;

public class EmployeeOperationClaimManager : IEmployeeOperationClaimService
{
    IEmployeeOperationClaimDal _employeeOperationClaimDal;
    IMapper _mapper;

    public EmployeeOperationClaimManager(IEmployeeOperationClaimDal employeeOperationClaimDal, IMapper mapper)
    {
        _employeeOperationClaimDal = employeeOperationClaimDal;
        _mapper = mapper;
    }

    public async Task<IList<OperationClaim>> GetClaims(Guid id)
    {
        var userOperationClaims = await _employeeOperationClaimDal.GetListAsync(u => u.EmployeeId == id,
                                                               include: u => u.Include(u => u.OperationClaim));
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
            { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
        return operationClaims;
    }
}