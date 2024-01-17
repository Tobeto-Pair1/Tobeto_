using Business.Abstract;
using Business.DTOs.CourseStudent;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentsController : ControllerBase
    {
        ICourseStudentService _courseStudentService;

        public CourseStudentsController(ICourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseStudentRequest createCourseStudentRequest)
        {

            var result = await _courseStudentService.Add(createCourseStudentRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseStudentRequest updateCourseStudentRequest)
        {

            var result = await _courseStudentService.Update(updateCourseStudentRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseStudentRequest deleteCourseStudentRequest)
        {


            var result = await _courseStudentService.Delete(deleteCourseStudentRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _courseStudentService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
