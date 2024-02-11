using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Entities.Concretes;

namespace Business.Rules;

public class BlogPressBusinessRules : BaseBusinessRules
{
    public async Task ThrowExceptionIfBlogPressIsNull(BlogPress blogPress)
    {
        if (blogPress == null) throw new BusinessException(BusinessMessages.BlogNotFound);
    }
}
