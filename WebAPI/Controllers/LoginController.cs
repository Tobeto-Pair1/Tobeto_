using Azure.Core;
using Business.DTOs.Login;
using Business.Validations;
using DataAccess.Context;
using Entities.Concretes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class LoginController : ControllerBase
{

    private readonly UserManager<AppUser> _userManager;
    //private readonly TobetoDbContext _applicationDbContext;
    private readonly SignInManager<AppUser> _signInManager;
    // private readonly JWTService _jWTService;


    public LoginController(UserManager<AppUser> userManager,
                          
                           SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
       
        _signInManager = signInManager;
    }



    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto loginRequest)
    {


        LoginValidate validate = new();
        ValidationResult validateResult = validate.Validate(loginRequest);
        if(!validateResult.IsValid) {

            var errorMessages = validateResult.Errors.Select(error => error.ErrorMessage).ToList();
            return StatusCode(422, errorMessages);

        }



        AppUser? appUser = await _userManager.FindByNameAsync(loginRequest.UserNameOrEmail);
        if (appUser is null)
        {
            appUser = await _userManager.FindByEmailAsync(loginRequest.UserNameOrEmail);
            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı bulunamadı!" });
            }
        }


        var result = await _signInManager.CheckPasswordSignInAsync(appUser, loginRequest.Password, true);


        if (result.IsLockedOut && appUser.LockoutEnd is not null)
        {



            TimeSpan? timeSpan = (appUser.LockoutEnd) - DateTime.UtcNow;

            return BadRequest(new { Message = "Şifreniz " + Math.Ceiling(timeSpan.Value.TotalMinutes) + " e kadar kilitlendi" });
        }


        if (result.IsNotAllowed)
        {

            return BadRequest(new { Message = "Emailiniz Onaylı Değil" });
        }
        if (!result.Succeeded)
        {

            return BadRequest(new { Message = "Şifreniz Hatalı" });
        }

        return Ok(new { Message = "Giriş Başarılı" });

        //var roles = _applicationDbContext.AppUserRoles
        //    .Where(o => o.UserId == appUser.Id)
        //    .Include(p => p.Role)
        //    .Select(s => s.Role!.Name)
        //    .ToList();

        //var resultToken = _jWTService.CreateToken(appUser, roles, loginRequest.RememberMe);


        //return Ok(new { AccessToken = resultToken });

    }





}
