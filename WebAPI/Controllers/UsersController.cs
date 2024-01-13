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
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
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
