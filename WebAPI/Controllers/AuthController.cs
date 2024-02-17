using Business.Abstract;
using Business.DTOs.Employees;
using Business.DTOs.Instructors;
using Business.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginRequest userForLoginRequest)
    {
        var loginResult = await _authService.Login(userForLoginRequest);

        return Ok(loginResult);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterRequest userForRegisterRequest)
    {
        var registerResult = await _authService.Register(userForRegisterRequest, userForRegisterRequest.Password);

        return Ok(registerResult);
    }
}
