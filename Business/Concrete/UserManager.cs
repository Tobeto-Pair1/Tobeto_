using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
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
    IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        await _userDal.AddAsync(user);
       
    }
}
