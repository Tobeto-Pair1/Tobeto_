using Business.Abstract;
using Business.Dtos.Requests;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
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
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAsyncLessonRequest updateAsyncLessonRequest)
        {

            var result = await _asyncLessonService.Update(updateAsyncLessonRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
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
    }
}
