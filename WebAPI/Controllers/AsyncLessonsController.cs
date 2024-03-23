using Business.Abstract;
using Business.DTOs.AsyncLessons;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncLessonsController : ControllerBase
    {

        IAsyncLessonService _asyncLessonService;

        public AsyncLessonsController(IAsyncLessonService asyncLessonService)
        {
            _asyncLessonService = asyncLessonService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateAsyncLessonRequest createAsyncLessonRequest)
        {

            var result = await _asyncLessonService.Add(createAsyncLessonRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAsyncLessonRequest updateAsyncLessonRequest)
        {

            var result = await _asyncLessonService.Update(updateAsyncLessonRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAsyncLessonRequest deleteAddressRequest)
        {

            var result = await _asyncLessonService.Delete(deleteAddressRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _asyncLessonService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _asyncLessonService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("getListByCourseModule")]
        public async Task<IActionResult> GetListByCourseModule(Guid id)
        {

            var result = await _asyncLessonService.GetListByCourseModule(id);

            return Ok(result);
        }
    }
}
