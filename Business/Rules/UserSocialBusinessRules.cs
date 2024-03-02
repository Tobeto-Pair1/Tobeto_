using Business.DTOs.UserSocials;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.Rules;

public class UserSocialBusinessRules : BaseBusinessRules
{
    IUserSocialDal _userSocialDal;

    public UserSocialBusinessRules(IUserSocialDal userSocialDal)
    {
        _userSocialDal = userSocialDal;
    }
    public async Task IfSocialMediaGreaterThanOrEqualToThree(Guid Id)
    {

        var socialMediaCheck = await _userSocialDal.GetListAsync(us => us.Id == Id);

        if (socialMediaCheck.Count >= 3)
        {
            throw new BusinessException(BusinessMessages.SocialMediaLimit);
        }
    }

    public async Task SocialMediaCanNotBeDuplicated(CreateUserSocialRequest createUserSocialRequest)
    {
        var result = await _userSocialDal.GetListAsync(l => l.UserId == createUserSocialRequest.UserId);
        foreach (var item in result.Items)
        {
            if (createUserSocialRequest.SocialMediaId == item.SocialMediaId)
            {
                if (createUserSocialRequest.Link == item.Link)
                {
                    throw new BusinessException(BusinessMessages.SocialMediaAlreadyExists);

                }
            }

        }
    }
}
