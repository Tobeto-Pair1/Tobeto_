using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Rules;

public class ResetTokenBusinessRules : BaseBusinessRules
{
    public Task ResetTokenMustExist(ResetToken? resetToken)
    {
        if (resetToken == null)
            throw new BusinessException(BusinessMessages.RefreshDontExists);

        return Task.CompletedTask;
    }

    public Task ResetTokenShouldBeActive(ResetToken resetToken)
    {
        if (resetToken.Revoked != null && DateTime.UtcNow >= resetToken.Expires)
            throw new BusinessException(BusinessMessages.InvalidResetToken);
        return Task.CompletedTask;
    }

    public Task UserShouldBeExistsWhenSelected(UserAuth? user)
    {
        if (user == null)
            throw new BusinessException(BusinessMessages.UserDontExists);
        return Task.CompletedTask;
    }
    public Task ResetTokenShouldBeExists(ResetToken? resetToken)
    {
        if (resetToken == null)
            throw new BusinessException(BusinessMessages.RefreshDontExists);
        return Task.CompletedTask;
    }
}
