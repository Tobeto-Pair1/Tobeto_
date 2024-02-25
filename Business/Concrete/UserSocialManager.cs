using AutoMapper;
using Business.Abstract;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Business.DTOs.UserSocials;
using Business.Rules;

namespace Business.Concrete;

public class UserSocialManager : IUserSocialService
{
    private readonly IUserSocialDal _userSocialDal;
    private readonly IMapper _mapper;
    private readonly UserSocialBusinessRules _userSocialBusinessRules;

    public UserSocialManager(IUserSocialDal userSocialDal, IMapper mapper, UserSocialBusinessRules userSocialBusinessRules)
    {
        _userSocialDal = userSocialDal;
        _mapper = mapper;
        _userSocialBusinessRules = userSocialBusinessRules;
    }

    public async Task<CreatedUserSocialResponse> Add(CreateUserSocialRequest createUserSocialRequest)
    {
        await _userSocialBusinessRules.SocialMediaCanNotBeDuplicated(createUserSocialRequest);
        UserSocial userSocial = _mapper.Map<UserSocial>(createUserSocialRequest);
        UserSocial createdUserSocial = await _userSocialDal.AddAsync(userSocial);
        CreatedUserSocialResponse createdUserSocialResponse = _mapper.Map<CreatedUserSocialResponse>(createdUserSocial);
        return createdUserSocialResponse;
    }

    public async Task<DeletedUserSocialResponse> Delete(DeleteUserSocialRequest deleteUserSocialRequest)
    {
        UserSocial userSocial = await _userSocialDal.GetAsync(u => u.Id == deleteUserSocialRequest.Id);
        UserSocial deletedUserSocial = await _userSocialDal.DeleteAsync(userSocial);
        DeletedUserSocialResponse deletedUserSocialResponse = _mapper.Map<DeletedUserSocialResponse>(deletedUserSocial);
        return deletedUserSocialResponse;
    }

    public async Task<IPaginate<GetListUserSocialResponse>> GetListAsync(PageRequest pageRequest)
    {

        var data = await _userSocialDal.GetListAsync(include: a => a.Include(a => a.SocialMedia),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserSocialResponse>>(data);
        return result;
    }
    public async Task<IPaginate<GetListUserSocialResponse>> GetListByUser(Guid userId)
    {
        var data = await _userSocialDal.GetListAsync(predicate: a => a.UserId == userId);

        var result = _mapper.Map<Paginate<GetListUserSocialResponse>>(data);
        return result;
    }
    public async Task<UpdatedUserSocialResponse> Update(UpdateUserSocialRequest updateUserSocialRequest)
    {
        UserSocial userSocial = await _userSocialDal.GetAsync(u => u.Id == updateUserSocialRequest.Id);
        _mapper.Map(updateUserSocialRequest, userSocial);
        UserSocial updatedUserSocial = await _userSocialDal.UpdateAsync(userSocial);
        UpdatedUserSocialResponse updatedUserSocialResponse = _mapper.Map<UpdatedUserSocialResponse>(updatedUserSocial);
        return updatedUserSocialResponse;
    }
}
