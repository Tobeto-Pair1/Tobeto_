using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynchronLessonDetailsController : ControllerBase
    {
        ISynchronLessonDetailService _synchronLessonDetailService;

        public SynchronLessonDetailsController(ISynchronLessonDetailService synchronLessonDetailService)
        {
            _synchronLessonDetailService = synchronLessonDetailService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateSynchronLessonDetailRequest createSynchronLessonDetailRequest)
        {

            var result = await _synchronLessonDetailService.Add(createSynchronLessonDetailRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSynchronLessonDetailRequest updateSynchronLessonDetailRequest)
        {

            var result = await _synchronLessonDetailService.Update(updateSynchronLessonDetailRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSynchronLessonDetailRequest deleteSynchronLessonDetailRequest)
        {


            var result = await _synchronLessonDetailService.Delete(deleteSynchronLessonDetailRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _synchronLessonDetailService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
