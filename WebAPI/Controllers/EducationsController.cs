using Business.Abstract;
using Business.Dtos.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        IEducationService _educationService;

        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateEducationRequest createEducationRequest)
        {
            await _educationService.Add(createEducationRequest);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteEducationRequest deleteteEducationRequest)
        {
            await _educationService.Delete(deleteteEducationRequest);
            return Ok();

        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _educationService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

