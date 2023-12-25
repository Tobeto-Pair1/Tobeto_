using Business.Abstract;
using Business.DTOs.AboutOfCourses;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutOfCoursesController : ControllerBase
    {
        IAboutOfCourseService _aboutOfCourseService;

        public AboutOfCoursesController(IAboutOfCourseService aboutOfCourseService)
        {
            _aboutOfCourseService = aboutOfCourseService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateAboutOfCourseRequest createAboutOfCourseRequest)
        {

            var result = await _aboutOfCourseService.Add(createAboutOfCourseRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAboutOfCourseRequest updateAboutOfCourseRequest)
        {

            var result = await _aboutOfCourseService.Update(updateAboutOfCourseRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAboutOfCourseRequest deleteAboutOfCourseRequest )
        {


            var result = await _aboutOfCourseService.Delete(deleteAboutOfCourseRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _aboutOfCourseService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}

