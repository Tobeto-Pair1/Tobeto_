using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var result = await _userLanguageDal.GetListAsync(l => l.UserId == userId);
        foreach (var item in result.Items)
        {

            if (foreignLanguageId == item.ForeignLanguageId)
            {
                throw new BusinessException(BusinessMessages.LanguageAlreadyExists);
            }
        }
    }

}
