using AutoMapper;
using Business.Abstract;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    IUserOperationClaimDal _userOperationClaimDal;
    IMapper _mapper;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
    {
        _userOperationClaimDal = userOperationClaimDal;
        _mapper = mapper;
    }

    public async Task<IList<OperationClaim>> GetClaims(int id)
    {
        var userOperationClaims = await _userOperationClaimDal.GetListAsync(u => u.UserId == id,
                                                               include: u => u.Include(u => u.OperationClaim));
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
            { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
        return operationClaims;
    }
}