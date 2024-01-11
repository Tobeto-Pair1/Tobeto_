using Business.DTOs.Users;
using Entities.Concretes;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAuthService
{
    Task<CreatedUserResponse> Register(CreateUserRequest createUserRequest, string password);
    //Task<User> Login(UserForLoginDto userForLoginDto);
    //Task UserExists(string email);
    //Task<AccessToken> CreateAccessToken(User user);
}
