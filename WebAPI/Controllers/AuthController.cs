using Business.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{


    [HttpPost]
    public IActionResult Login(LoginRequest loginRequest)
    {

        return Ok();
    }




}
