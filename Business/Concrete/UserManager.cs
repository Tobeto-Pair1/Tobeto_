using Business.Abstract;
using Core.DataAccess.Dynamic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{


     IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task Add(User user)
    {
        await _userDal.AddAsync(user);
    }


    public void Delete(User user)
    {
        throw new NotImplementedException();
    }
}


