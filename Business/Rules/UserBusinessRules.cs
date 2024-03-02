using Business.DTOs.Users;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Verification.TCKN;

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
            throw new BusinessException("TC Kimlik numarası doğrulanamadı.");
    }
}