using Business.Abstract;
using Business.DTOs.CourseModule;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseModulesController : ControllerBase
    {
        ICourseModuleService _courseModuleService;

        public CourseModulesController(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseModuleRequest createCourseModuleRequest)
        {
            await _courseModuleService.Add(createCourseModuleRequest);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseModuleRequest deleteCourseModuleRequest)
        {
            await _courseModuleService.Delete(deleteCourseModuleRequest);
            return Ok();

        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseModuleService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseModuleRequest updateCourseModuleRequest)
        {
            await _courseModuleService.Update(updateCourseModuleRequest);
            return Ok();

        }
    }
}
