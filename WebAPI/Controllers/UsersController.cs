using Business.Abstract;
using Business.DTOs.Login;
using Business.DTOs.Users;
using Business.Services;
using Core.DataAccess.Paging;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IUserService _userService;
    private readonly TobetoDbContext _tobetoDbContext;
    private readonly JWTService _jWTService;

    public UsersController(IUserService userService,
                       TobetoDbContext tobetoDbContext,
                       JWTService jWTService)
    {
        _userService = userService;
        _tobetoDbContext = tobetoDbContext;
        _jWTService = jWTService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest request ,
                                         CancellationToken cancellationToken)
    {

        //User user = _tobetoDbContext.Users
         //.FirstOrDefault(o => o.Email == request.Email 
         //|| 
         //o.IdentityNumber == request.IdentityNumber);


        //if(user is not null)
        //{
            //return BadRequest(new { Message = "Kullanıcı Bulunamadı" });
        //}

        User user  = new()
        {
            IdentityNumber = request.IdentityNumber,
            Email = request.Email,
            AboutMe = request.AboutMe,
            BirthDate = request.BirthDate,
            FirstName = request.FirstName,
            Lastname = request.Lastname
        };
        _tobetoDbContext.Users.Add(user);
        _tobetoDbContext.SaveChanges();
        var resultToken = _jWTService.CreateToken(user , false);


        return Ok(new { AccessToken = resultToken });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserRequest deleteUserRequest)
    {
        var result = await _userService.Delete(deleteUserRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest)
    {
        var result = await _userService.Update(updateUserRequest);
        return Ok(result);
    }

    [HttpGet("getlist")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListAsync(pageRequest);
        return Ok(result);
    }

}
