using Business.Abstract;
using Business.DTOs.Employees;
using Business.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthEmployeeController : Controller
{
    private IEmployeeAuthService _adminAuthService;

    public AuthEmployeeController(IEmployeeAuthService adminAuthService)
    {
        _adminAuthService = adminAuthService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] EmployeeForLoginRequest employeeForLoginRequest)
    {
        var loginResult = await _adminAuthService.Login(employeeForLoginRequest);

        return Ok(loginResult);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] EmployeeForRegisterRequest employeeForRegisterRequest)
    {
        var registerResult = await _adminAuthService.Register(employeeForRegisterRequest, employeeForRegisterRequest.Password);

        return Ok(registerResult);

    }
}
