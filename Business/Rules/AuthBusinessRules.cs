using Business.Abstract;
using Business.Dtos.RefreshTokens;
using Business.DTOs.Users;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;
    public AuthBusinessRules(IUserService userService)
    {
        _userService = userService;
    }

    public async Task UserWithSameEmailShouldNotExist(string email)
    {
        var userToCheck = await _userService.GetByMail(email);
        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }

    public async Task<UserAuth> UserWithSameEmailShouldExist(string email)
    {
        var userToCheck = await _userService.GetByMail(email);
        if (userToCheck == null) throw new BusinessException(BusinessMessages.UserDontExists);
        return userToCheck;

    }
    public async Task<UserAuth> LoginInformationCheck(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _userService.GetByMail(userForLoginRequest.Email);
        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserDontExists);
        }
        if (!HashingHelper.VerifyPasswordHash(userForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordError);
        }
        return userToCheck;
    }
    public async Task ThrowExceptionIfCreateAccessTokenIsNull(RefreshTokenResponse refreshedTokenDto)
    {
        if (refreshedTokenDto == null)
            throw new BusinessException(BusinessMessages.CreateAccessTokenNot);

    }
}
