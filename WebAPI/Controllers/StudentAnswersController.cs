using Business.Abstract;
using Business.DTOs.StudentAnswers;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswersController : ControllerBase
    {
        IStudentAnswerService _studentAnswerService;

        public StudentAnswersController(IStudentAnswerService studentAnswerService)
        {
            _studentAnswerService = studentAnswerService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateStudentAnswerRequest createStudentAnswerRequest)
        {

            var result = await _studentAnswerService.Add(createStudentAnswerRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentAnswerRequest updateStudentAnswerRequest)
        {

            var result = await _studentAnswerService.Update(updateStudentAnswerRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentAnswerRequest deleteStudentAnswerRequest)
        {

            var result = await _studentAnswerService.Delete(deleteStudentAnswerRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentAnswerService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
