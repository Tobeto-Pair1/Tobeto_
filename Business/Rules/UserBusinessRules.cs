using Business.DTOs.Users;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Verification.TCKN;
using Entities.Concretes;
using Org.BouncyCastle.Crypto;

namespace Business.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IVerificationService _verificationService;

    public UserBusinessRules(IVerificationService verificationService)
    {
        _verificationService = verificationService;
    }

    public async Task VerifyTCKN(UpdateUserRequest updateUserRequest)
    {
        var verificationResult = await _verificationService.VerifyTCKN(long.Parse(updateUserRequest.IdentityNumber),
            updateUserRequest.FirstName, updateUserRequest.LastName, updateUserRequest.BirthDate.Year);

        if (!verificationResult)
            throw new BusinessException(BusinessMessages.TCKNCouldNotBeVerified);
    }
    public Task UserShouldBeExistsWhenSelected(User userAuth)
    {
        if (userAuth == null)
            throw new BusinessException(BusinessMessages.UserDontExists);
        return Task.CompletedTask;
    }
    public Task UserPasswordShouldBeMatched(User userAuth, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, userAuth.PasswordHash, userAuth.PasswordSalt))
            throw new BusinessException(BusinessMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }
    public Task UserPasswordAndCheckPassword(string newPassword, string checkNewPassword)
    {
        if (newPassword != checkNewPassword)
            throw new BusinessException(BusinessMessages.PasswordHaveToEqualToCheckPassword);
        return Task.CompletedTask;
    }
}