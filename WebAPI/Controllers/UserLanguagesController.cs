using Business.Abstract;
using Business.DTOs.UserLanguages;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        IUserLanguageService _userLanguageService;

        public UserLanguagesController(IUserLanguageService userLanguageService)
        {
            _userLanguageService = userLanguageService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateUserLanguageRequest createUserLanguageRequest)
        {

            var result = await _userLanguageService.Add(createUserLanguageRequest);

            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserLanguageRequest deleteUserLanguageRequest)
        {
            var result = await _userLanguageService.Delete(deleteUserLanguageRequest);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserLanguageRequest updateUserLanguageRequest)
        {
            var result = await _userLanguageService.Update(updateUserLanguageRequest);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userLanguageService.GetListAsync(pageRequest);
            return Ok(result);
        }
    
}
}
