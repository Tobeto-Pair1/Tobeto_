using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationController : ControllerBase
    {
        IUserEducationService _userEducationService;

        public UserEducationController(IUserEducationService userEducationService)
        {
            _userEducationService = userEducationService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateUserEducationRequest createUserEducationRequest)
        {

            var result = await _userEducationService.Add(createUserEducationRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserEducationRequest updateUserEducationRequest)
        {

            var result = await _userEducationService.Update(updateUserEducationRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserEducationRequest deleteUserEducationRequest)
        {


            var result = await _userEducationService.Delete(deleteUserEducationRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _userEducationService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
