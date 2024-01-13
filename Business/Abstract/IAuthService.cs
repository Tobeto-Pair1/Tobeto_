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
    //IDataResult<UserAuth> Register(UserForRegisterDto userForRegisterDto, string password);
    Task<UserAuth> Register(UserForRegisterRequest userForRegisterRequest, string password);

    //IDataResult<UserAuth> Login(UserForLoginDto userForLoginDto);
    Task<UserAuth> Login(UserForLoginRequest userForLoginRequest);
    //IResult UserExists(string email);
    void UserExists(string email);
    //IDataResult<AccessToken> CreateAccessToken(UserAuth user);
    AccessToken CreateAccessToken(UserAuth userAuth);
}



