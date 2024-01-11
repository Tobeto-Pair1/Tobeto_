using Azure.Core;
using Business.Abstract;
using Business.DTOs.Users;
using Business.Services;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private readonly JWTService _jWTService;


    public AuthManager(IUserService userService, JWTService jWTService)
    {
        _userService = userService;
        _jWTService = jWTService;
    }
    public Task<CreatedUserResponse> Register(CreateUserRequest createUserRequest, string password)
    {
        CreateUserRequest createdUserRequest = new()
        {
            FirstName = createUserRequest.FirstName,
            Lastname = createUserRequest.Lastname,
            Email = createUserRequest.Email,
            PhoneNumber = createUserRequest.PhoneNumber,
        };
        return _userService.Add(createdUserRequest);
    }
    //public AccessToken CreateAccessToken(User user)
    //{
    //    //var claims = _userService.GetClaims(user);
    //    var accessToken = _jWTService.CreateToken(user, false);
    //    return new AccessToken = accessToken;
    //}
}
