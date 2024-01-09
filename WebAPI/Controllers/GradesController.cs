using Business.Abstract;
using Business.DTOs.Grades;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateGradeRequest createGradeRequest)
        {

            var result = await _gradeService.Add(createGradeRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGradeRequest updateGradeRequest)
        {

            var result = await _gradeService.Update(updateGradeRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGradeRequest deleteGradeRequest)
        {

            var result = await _gradeService.Delete(deleteGradeRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _gradeService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
