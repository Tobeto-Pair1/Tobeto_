using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class UserSocialBusinessRules : BaseBusinessRules
    {
        IUserSocialDal _userSocialDal;

        public UserSocialBusinessRules(IUserSocialDal userSocialDal)
        {
            _userSocialDal = userSocialDal;
        }
        public async Task IfSocialMediaGreaterThanOrEqualToThree(Guid Id)
        {
        
            var  socialMediaCheck = await _userSocialDal.GetListAsync(us => us.Id == Id);

            if (socialMediaCheck.Count >= 3)
            {
                throw new BusinessException(BusinessMessages.SocialMediaLimit);
            }
        }

        //public async Task IfSocialMediaIsInstagram(string Name)
        //{
        //    var socialMediaCheck = await _userSocialDal.GetAsync(us => us.SocialMedia.Name == Name);

        //    if (socialMediaCheck.SocialMedia.Link.StartsWith!="www.instagram.com")
        //    {
        //        throw new BusinessException
        //    }
        //}
    }
}
