using Business.Abstract;
using Core.DTOs;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{

   private readonly IUserService userService;



    public UsersController(IUserService userService)
    {
        this.userService = userService;
       
        
    }



    [HttpPost]
    public async Task<IActionResult> Register( [FromBody] User user)
    {

        var response = await userService.Add(user);



        return Ok(response);
    }




}
