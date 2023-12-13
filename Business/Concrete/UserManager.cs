using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{

    IUserDal _userDal;


    public UserManager(IUserDal userDal)
    {
        this._userDal = userDal;

    }

    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        throw new NotImplementedException();
    }
}
