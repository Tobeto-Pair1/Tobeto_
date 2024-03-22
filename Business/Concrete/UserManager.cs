using AutoMapper;
using Business.Abstract;
using Business.Dtos.RefreshTokens;
using Business.DTOs.Users;
using Business.Rules;
using Business.Services.Tokens;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;


namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;


    public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules, ITokenService tokenService)
    {
        _userDal = userDal;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _tokenService = tokenService;
    }
    public async Task<DeletedUserResponse> Delete(Guid id)
    {
        User? user = await _userDal.GetAsync(u => u.Id == id);
        await _userDal.DeleteAsync(user);
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(user);
        return deletedUserResponse;
    }

    public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userDal.GetListAsync(include: l => l
            .Include(l => l.Address)
            .Include(l => l.Address.City)
            .Include(l => l.Address.Country)
            .Include(l => l.Address.Town),
                     index: pageRequest.PageIndex,
                     size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        await _userBusinessRules.VerifyTCKN(updateUserRequest);
        User? user = await _userDal.GetAsync(u => u.Id == updateUserRequest.Id);
        _mapper.Map(updateUserRequest, user);

        User userUpdated = await _userDal.UpdateAsync(user);

        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(userUpdated);

        return updatedUserResponse;
    }
    public async Task<RefreshTokenResponse> UpdatePassword(UpdatePasswordRequest updatePasswordRequest, string IpAddress)
    {
        User? user = await _userDal.GetAsync(predicate: u => u.Id == updatePasswordRequest.Id);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserPasswordShouldBeMatched(userAuth: user!, updatePasswordRequest.LastPassword);
        await _userBusinessRules.UserPasswordAndCheckPassword(updatePasswordRequest.NewPassword, updatePasswordRequest.CheckNewPassword);
        user = _mapper.Map(updatePasswordRequest, user);

        HashingHelper.CreatePasswordHash(
            updatePasswordRequest.NewPassword,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user!.PasswordHash = passwordHash;
        user!.PasswordSalt = passwordSalt;

        User updatedUser = await _userDal.UpdateAsync(user!);
        UserAuth userAuth = _mapper.Map<UserAuth>(updatedUser);

        var createdAccessToken = await _tokenService.CreateAccessToken(userAuth);

        RefreshToken createdRefreshToken = await _tokenService.CreateRefreshToken(userAuth, IpAddress);
        await _tokenService.AddRefreshToken(createdRefreshToken);
        await _tokenService.DeleteOldRefreshTokens(updatedUser.Id);

        RefreshTokenResponse registeredDto = new()
        {
            RefreshToken = createdRefreshToken,
            AccessToken = createdAccessToken,
        };
        return registeredDto;


    }

    public async Task<UserAuth> Add(UserAuth userAuth)
    {
        User user = _mapper.Map<User>(userAuth);
        User userCreated = await _userDal.AddAsync(user);
        UserAuth userAuthMap = _mapper.Map<UserAuth>(userCreated);
        return userAuthMap;
    }

    public async Task<UserAuth> GetByMail(string email)
    {
        var result = await _userDal.GetAsync(u => u.Email == email);
        UserAuth userAuth = _mapper.Map<UserAuth>(result);
        return userAuth;
    }
    public async Task<UserAuth> GetById(Guid id)
    {
        User? user = await _userDal.GetAsync(i => i.Id == id);
        UserAuth userAuth = _mapper.Map<UserAuth>(user);
        return userAuth;
    }
}
