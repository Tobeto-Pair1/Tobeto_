using AutoMapper;
using Business.Abstract;
using Business.DTOs.UserLanguages;
using Business.Rules;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class UserLanguageManager : IUserLanguageService
{
    private readonly IUserLanguageDal _userLanguageDal;
    private readonly IMapper _mapper;
    UserLanguageBusinessRules _userLanguageBusinessRules;
    public UserLanguageManager(IUserLanguageDal userLanguageDal, IMapper mapper, UserLanguageBusinessRules userLanguageBusinessRules)
    {
        _mapper = mapper;
        _userLanguageDal = userLanguageDal;
        _userLanguageBusinessRules = userLanguageBusinessRules;
    }

    public async Task<CreatedUserLanguageResponse> Add(CreateUserLanguageRequest createUserLanguageRequest)
    {
        await _userLanguageBusinessRules.LanguageCanNotBeDuplicated(createUserLanguageRequest.UserId, createUserLanguageRequest.ForeignLanguageId);
        UserLanguage userLanguage = _mapper.Map<UserLanguage>(createUserLanguageRequest);
        UserLanguage createdUserLanguage = await _userLanguageDal.AddAsync(userLanguage);
        CreatedUserLanguageResponse createdUserLanguageResponse = _mapper.Map<CreatedUserLanguageResponse>(createdUserLanguage);
        return createdUserLanguageResponse;
    }

 

    public async Task<DeletedUserLanguageResponse> Delete(DeleteUserLanguageRequest deleteUserLanguageRequest)
    {
        UserLanguage userLanguage = _mapper.Map<UserLanguage>(deleteUserLanguageRequest);
        UserLanguage deletedUserLanguage = await _userLanguageDal.DeleteAsync(userLanguage);
        DeletedUserLanguageResponse deletedUserLanguageResponse = _mapper.Map<DeletedUserLanguageResponse>(deletedUserLanguage);
        return deletedUserLanguageResponse;
    }

    public async Task<IPaginate<GetListUserLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userLanguageDal.GetListAsync(include: l => l.Include(l => l.User)
             .Include(l=>l.ForeignLanguage).Include(l=>l.ForeignLanguageLevel),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserLanguageResponse>>(data);
        return result;
    }
    public async Task<IPaginate<GetListUserLanguageResponse>> GetListByUser(Guid UserId)
    {
        var data = await _userLanguageDal.GetListAsync(predicate: l=>l.UserId == UserId, 
            include: l => l.Include(l => l.User).Include(l => l.ForeignLanguage).Include(l => l.ForeignLanguageLevel));

        var result = _mapper.Map<Paginate<GetListUserLanguageResponse>>(data);
        return result;
    }
    public async Task<UpdatedUserLanguageResponse> Update(UpdateUserLanguageRequest updateUserLanguageRequest)
    {
        UserLanguage userLanguage = await _userLanguageDal.GetAsync(u => u.Id == updateUserLanguageRequest.Id);
        _mapper.Map(updateUserLanguageRequest, userLanguage);
        UserLanguage updateUserLanguage = await _userLanguageDal.UpdateAsync(userLanguage);
        UpdatedUserLanguageResponse updateUserLanguageResponse = _mapper.Map<UpdatedUserLanguageResponse>(updateUserLanguage);
        return updateUserLanguageResponse;
    }
}
