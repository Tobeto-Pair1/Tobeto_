﻿using Business.Abstract;
using Business.DTOs.UserSocials;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSocialsController : ControllerBase
{

    IUserSocialService _userSocialService;

    public UserSocialsController(IUserSocialService UserSocialService)
    {
        _userSocialService = UserSocialService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateUserSocialRequest createUserSocialRequest)
    {

        var result = await _userSocialService.Add(createUserSocialRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserSocialRequest updateUserSocialRequest)
    {

        var result = await _userSocialService.Update(updateUserSocialRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserSocialRequest deleteUserSocialRequest)
    {
        var result = await _userSocialService.Delete(deleteUserSocialRequest);
        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        var result = await _userSocialService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("getListByUser")]
    public async Task<IActionResult> GetListByUser(Guid id)
    {

        var result = await _userSocialService.GetListByUser(id);
        return Ok(result);
    }
}
