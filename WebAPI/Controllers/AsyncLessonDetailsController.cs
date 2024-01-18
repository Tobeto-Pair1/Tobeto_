using Business.Abstract;
using Business.DTOs.AsyncLessonDetail;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncLessonDetailDetailsController : ControllerBase
    {
        IAsyncLessonDetailService _asyncLessonDetailService;

        public AsyncLessonDetailDetailsController(IAsyncLessonDetailService asyncLessonDetailService)
        {
            _asyncLessonDetailService = asyncLessonDetailService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateAsyncLessonDetailRequest createAsyncLessonDetailRequest)
        {

            var result = await _asyncLessonDetailService.Add(createAsyncLessonDetailRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAsyncLessonDetailRequest updateAsyncLessonDetailRequest)
        {

            var result = await _asyncLessonDetailService.Update(updateAsyncLessonDetailRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAsyncLessonDetailRequest asyncLessonDetailRequest)
        {

            var result = await _asyncLessonDetailService.Delete(asyncLessonDetailRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _asyncLessonDetailService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

