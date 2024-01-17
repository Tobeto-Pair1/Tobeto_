using Business.Abstract;
using Business.DTOs.CourseProgram;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseProgramsController : ControllerBase
    {
        ICourseProgramService _courseProgramService;

        public CourseProgramsController(ICourseProgramService courseProgramService)
        {
            _courseProgramService = courseProgramService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseProgramRequest createCourseProgramRequest)
        {
            await _courseProgramService.Add(createCourseProgramRequest);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseProgramRequest deleteCourseProgramRequest)
        {
            await _courseProgramService.Delete(deleteCourseProgramRequest);
            return Ok();

        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseProgramService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseProgramRequest updateCourseProgramRequest)
        {
            await _courseProgramService.Update(updateCourseProgramRequest);
            return Ok();

        }
    }
}
