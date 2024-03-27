using Business.Abstract;
using Business.DTOs.Users;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;
    private readonly IRefreshTokenService _refreshTokenService;
    public AuthController(IAuthService authService, IRefreshTokenService refreshTokenService)
    {
        _authService = authService;
        _refreshTokenService = refreshTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginRequest userForLoginRequest)
    {
        string? IpAddress = getIpAddress();
        var loginResult = await _authService.Login(userForLoginRequest, IpAddress);
        setRefreshTokenToCookie(loginResult.RefreshToken);
        return Ok(loginResult.AccessToken);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterRequest userForRegisterRequest)
    {
        string? IpAddress = getIpAddress();
        var registerResult = await _authService.Register(userForRegisterRequest, userForRegisterRequest.Password, IpAddress);
        setRefreshTokenToCookie(registerResult.RefreshToken);
        return Ok(registerResult);

    }
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = await _refreshTokenService.RefreshAccessToken(getRefreshTokenFromCookie(), getIpAddress());
        setRefreshTokenToCookie(refreshToken.RefreshToken);
        return Ok(refreshToken.AccessToken);
    }

    [HttpPut("RevokeToken")]
    public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken)
    {
        var result = await _refreshTokenService.RevokedToken(refreshToken ?? getRefreshTokenFromCookie(), getIpAddress());
        return Ok(result);
    }

    private string getRefreshTokenFromCookie() =>
   Request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");

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
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddMinutes(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}
