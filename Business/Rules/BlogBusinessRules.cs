using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Entities.Concretes;
namespace Business.Rules;

public class BlogBusinessRules : BaseBusinessRules
{

    public async Task ThrowExceptionIfBlogIsNull(Blog blog)
    {
        if (blog == null) throw new BusinessException(BusinessMessages.BlogNotFound);
        
    }
}
