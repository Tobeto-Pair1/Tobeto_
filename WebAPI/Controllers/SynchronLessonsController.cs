using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynchronLessonsController : ControllerBase
    {
        ISynchronLessonService _synchronLessonService;

        public SynchronLessonsController(ISynchronLessonService synchronLessonService)
        {
            _synchronLessonService= synchronLessonService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateSynchronLessonRequest createSynchronLessonRequest)
        {

            var result = await _synchronLessonService.Add(createSynchronLessonRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSynchronLessonRequest updateSynchronLessonRequest)
        {

            var result = await _synchronLessonService.Update(updateSynchronLessonRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSynchronLessonRequest deleteSynchronLessonRequest)
        {


            var result = await _synchronLessonService.Delete(deleteSynchronLessonRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _synchronLessonService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
