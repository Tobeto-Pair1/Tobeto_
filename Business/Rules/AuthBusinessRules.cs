using Business.Abstract;
using Business.DTOs.Users;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcrens.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.VisualBasic;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;

    public AuthBusinessRules(IUserService userService)
    {
        _userService = userService;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        var userToCheck = await _userService.GetByMail(email);
        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }

    public async Task<UserAuth> LoginInformationCheck(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _userService.GetByMail(userForLoginRequest.Email);
        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserNotFound);
        }
        if (!HashingHelper.VerifyPasswordHash(userForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordError);
        }
        return userToCheck;
    }
    public Task ThrowExceptionIfCreateAccessTokenIsNull(AccessToken accessToken)
    {
        if (accessToken == null)
            throw new BusinessException(BusinessMessages.CreateAccessTokenNot);
        return Task.CompletedTask;
    }
}