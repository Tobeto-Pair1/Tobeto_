using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstract;

namespace Business.Rules;

public class UserLanguageBusinessRules:BaseBusinessRules
{
    private readonly IUserLanguageDal _userLanguageDal;

    public UserLanguageBusinessRules(IUserLanguageDal userLanguageDal)
    {
        _userLanguageDal = userLanguageDal;
    }

    public async Task LanguageCanNotBeDuplicated(Guid userId, Guid foreignLanguageId)
    {
        var result = (await _userLanguageDal.GetListAsync(l => l.UserId == userId)).Items.Any(l=>l.ForeignLanguageId == foreignLanguageId);
        if (result != null)
        {
            throw new BusinessException(BusinessMessages.LanguageAlreadyExists);
        }
    }

}
