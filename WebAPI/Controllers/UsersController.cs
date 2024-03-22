using Business.Abstract;
using Business.DTOs.Requests;
using Business.DTOs.Users;
using Core.DataAccess.Paging;
using Core.Extensions;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _userService.Delete(id);
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
    [HttpPut("forPassword")]
    public async Task<IActionResult> UpdateForPassword([FromBody] UpdatePasswordRequest updatePasswordRequest)
    {
        updatePasswordRequest.Id = getAuthenticatedUserId();
        string? IpAddress = getIpAddress();
        var result = await _userService.UpdatePassword(updatePasswordRequest, IpAddress);
        setRefreshTokenToCookie(result.RefreshToken);
        return Ok(result.AccessToken);
    }
    protected Guid getAuthenticatedUserId()
    {
        Guid userId = HttpContext.User.GetUserId();
        return userId;
    }
    protected string getIpAddress()
    {
        string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"].ToString()
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }
    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddMinutes(2) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }

}
