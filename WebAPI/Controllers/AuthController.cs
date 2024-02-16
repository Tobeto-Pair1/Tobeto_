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
    [HttpPost("EmployeeLogin")]
    public async Task<IActionResult> EmployeeLogin([FromBody] EmployeeForLoginRequest employeeForLoginRequest)
    {
        var loginResult = await _authService.EmployeeLogin(employeeForLoginRequest);

        return Ok(loginResult);
    }

    [HttpPost("EmployeeRegister")]
    public async Task<IActionResult> EmployeeRegister([FromBody] EmployeeForRegisterRequest employeeForRegisterRequest)
    {
        var registerResult = await _authService.EmployeeRegister(employeeForRegisterRequest, employeeForRegisterRequest.Password);

        return Ok(registerResult);

    }

    [HttpPost("InstructorLogin")]
    public async Task<IActionResult> InstructorLogin([FromBody] InstructorForLoginRequest ınstructorForLoginRequest)
    {
        var loginResult = await _authService.InstructorLogin(ınstructorForLoginRequest);

        return Ok(loginResult);
    }

    [HttpPost("InstructorRegister")]
    public async Task<IActionResult> InstructorRegister([FromBody] InstructorForRegisterRequest ınstructorForRegisterRequest)
    {
        var registerResult = await _authService.InstructorRegister(ınstructorForRegisterRequest, ınstructorForRegisterRequest.Password);

        return Ok(registerResult);

    }
}
