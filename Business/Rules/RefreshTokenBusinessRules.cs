using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Rules;

public class RefreshTokenBusinessRules : BaseBusinessRules
{
    public Task RefreshTokenMustExist(RefreshToken? refreshToken)
    {
        if (refreshToken == null)
            throw new BusinessException(BusinessMessages.RefreshDontExists);

        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
    {
        if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires)
            throw new BusinessException(BusinessMessages.InvalidRefreshToken);
        return Task.CompletedTask;
    }

    public Task UserShouldBeExistsWhenSelected(UserAuth? user)
    {
        if (user == null)
            throw new BusinessException(BusinessMessages.UserDontExists);
        return Task.CompletedTask;
    }
    public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
    {
        if (refreshToken == null)
            throw new BusinessException(BusinessMessages.RefreshDontExists);
        return Task.CompletedTask;
    }
}
