using Core.Business;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class SocialMediaBusinessRules:BaseBusinessRules
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaBusinessRules(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

       
    }
}
