using Business.Abstract;
using Business.DTOs.Instructors;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthInstructorController : Controller
{
    private readonly IInstructorAuthService _ınstructorAuthService;

    public AuthInstructorController(IInstructorAuthService ınstructorAuthService)
    {
        _ınstructorAuthService = ınstructorAuthService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] InstructorForLoginRequest ınstructorForLoginRequest)
    {
        var loginResult = await _ınstructorAuthService.Login(ınstructorForLoginRequest);

        return Ok(loginResult);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] InstructorForRegisterRequest ınstructorForRegisterRequest)
    {
        var registerResult = await _ınstructorAuthService.Register(ınstructorForRegisterRequest, ınstructorForRegisterRequest.Password);

        return Ok(registerResult);

    }
}
