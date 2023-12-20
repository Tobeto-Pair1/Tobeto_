using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateStudentRequest createStudentRequest)
        {

            var result = await _studentService.Add(createStudentRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentRequest deleteStudentRequest)
        {
            var result = await _studentService.Delete(deleteStudentRequest);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentRequest updateStudentRequest)
        {
            var result = await _studentService.Update(updateStudentRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentService.GetListAsync(pageRequest);
            return Ok(result);
        }


      
    }
}