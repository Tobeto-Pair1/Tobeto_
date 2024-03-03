using Business.DTOs.Users;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Verification.TCKN;
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
}