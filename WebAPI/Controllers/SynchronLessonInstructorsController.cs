using Business.Abstract;
using Business.DTOs.SynchronLessonInstructors;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynchronLessonInstructorsController : ControllerBase
    {
        ISynchronLessonInstructorService _synchronLessonInstructorService;

        public SynchronLessonInstructorsController(ISynchronLessonInstructorService synchronLessonInstructorService)
        {
            _synchronLessonInstructorService = synchronLessonInstructorService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateSynchronLessonInstructorRequest createSynchronLessonInstructorRequest)
        {

            var result = await _synchronLessonInstructorService.Add(createSynchronLessonInstructorRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSynchronLessonInstructorRequest updateSynchronLessonInstructorRequest)
        {

            var result = await _synchronLessonInstructorService.Update(updateSynchronLessonInstructorRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSynchronLessonInstructorRequest deleteSynchronLessonInstructorRequest)
        {


            var result = await _synchronLessonInstructorService.Delete(deleteSynchronLessonInstructorRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _synchronLessonInstructorService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
