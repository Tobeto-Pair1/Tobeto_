using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //ilgili kullanıcı için claim varsa token oluşturur
        AccessToken CreateToken(UserAuth user, IList<OperationClaim> operationClaims);
    }
}
