using AutoMapper;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Business.Abstract;
using Business.DTOs.UserSkills;
namespace Business.Concrete;

public class UserSkillManager : IUserSkillService
{
    private readonly IUserSkillDal _userSkillDal;
    private readonly IMapper _mapper;

    public UserSkillManager(IUserSkillDal userSkillDal, IMapper mapper)
    {
        _userSkillDal = userSkillDal;
        _mapper = mapper;
    }

    public async Task<CreatedUserSkillResponse> Add(CreateUserSkillRequest createUserSkillRequest)
    {
        UserSkill userSkill = _mapper.Map<UserSkill>(createUserSkillRequest);
        UserSkill createdUserSkill = await _userSkillDal.AddAsync(userSkill);
        CreatedUserSkillResponse createdUserSkillResponse = _mapper.Map<CreatedUserSkillResponse>(createdUserSkill);
        return createdUserSkillResponse;
    }

    public async Task<DeletedUserSkillResponse> Delete(DeleteUserSkillRequest deleteUserSkillRequest)
    {
        UserSkill userSkill = await _userSkillDal.GetAsync(u => u.Id == deleteUserSkillRequest.Id);
        _mapper.Map(deleteUserSkillRequest, userSkill);
        UserSkill deletedUserSkill = await _userSkillDal.DeleteAsync(userSkill);
        DeletedUserSkillResponse deletedUserSkillResponse = _mapper.Map<DeletedUserSkillResponse>(deletedUserSkill);
        return deletedUserSkillResponse;
    }

    public async Task<IPaginate<GetListUserSkillResponse>> GetListAsync(PageRequest pageRequest)
    {

        var data = await _userSkillDal.GetListAsync(include: a => a.Include(a => a.User).Include(a => a.Skill),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserSkillResponse>>(data);
        return result;
    }
    public async Task<IPaginate<GetListUserSkillResponse>> GetListByUser(Guid userId)
    {
        var data = await _userSkillDal.GetListAsync(predicate: a => a.UserId == userId);

        var result = _mapper.Map<Paginate<GetListUserSkillResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserSkillResponse> Update(UpdateUserSkillRequest updateUserSkillRequest)
    {
        UserSkill userSkill = await _userSkillDal.GetAsync(u => u.Id == updateUserSkillRequest.Id);
        _mapper.Map(updateUserSkillRequest, userSkill);
        UserSkill updatedUserSkill = await _userSkillDal.UpdateAsync(userSkill);
        UpdatedUserSkillResponse updatedUserSkillResponse = _mapper.Map<UpdatedUserSkillResponse>(updatedUserSkill);
        return updatedUserSkillResponse;
    }
}
