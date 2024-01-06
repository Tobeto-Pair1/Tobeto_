using Business.Abstract;
using Business.DTOs.Homeworks;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworksController : ControllerBase
    {
        IHomeworkService _homeworkService;

        public HomeworksController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateHomeworkRequest createHomeworkRequest)
        {

            var result = await _homeworkService.Add(createHomeworkRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateHomeworkRequest updateHomeworkRequest)
        {

            var result = await _homeworkService.Update(updateHomeworkRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteHomeworkRequest deleteHomeworkRequest)
        {

            var result = await _homeworkService.Delete(deleteHomeworkRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _homeworkService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
