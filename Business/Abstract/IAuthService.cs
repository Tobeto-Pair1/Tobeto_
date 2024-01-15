using Business.DTOs.Users;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAuthService
{
    Task<AccessToken> Register(UserForRegisterRequest userForRegisterRequest, string password);
    Task<AccessToken> Login(UserForLoginRequest userForLoginRequest);
    Task<AccessToken> CreateAccessToken(UserAuth userAuth);
}



