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

namespace Business.Rules
{
    public class UserLanguageBusinessRules:BaseBusinessRules
    {
        IUserLanguageDal _userLanguageDal;

        public UserLanguageBusinessRules(IUserLanguageDal userLanguageDal)
        {
            _userLanguageDal = userLanguageDal;
        }

        //public async Task LanguageIsExist(Guid Id) 
        //{
        //    var result = await _userLanguageDal.GetAsync(l => l.Id == Id) ;
        //    var result1 = await _userLanguageDal.GetListAsync(l => l.ForeignLanguageId == result.ForeignLanguageId);
        //    if (result>0)
        //    {
        //        throw new BusinessException(BusinessMessages.LanguageIsExist);
        //    }
            
        //}

    }
}
