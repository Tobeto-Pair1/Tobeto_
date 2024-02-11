using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class BlogBusinessRules : BaseBusinessRules
{

    public async Task ThrowExceptionIfBlogIsNull(Blog blog)
    {
        if (blog == null) throw new BusinessException(BusinessMessages.BlogNotFound);
        
    }
}
