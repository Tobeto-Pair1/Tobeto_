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
    public class InstructorsController : ControllerBase
    {
        IInstructorService _ınstructorService;

        public InstructorsController(IInstructorService ınstructorService)
        {
            _ınstructorService = ınstructorService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
        {

            var result = await _ınstructorService.Add(createInstructorRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {

            var result = await _ınstructorService.Update(updateInstructorRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructorRequest deleteInstructorRequest)
        {

            var result = await _ınstructorService.Delete(deleteInstructorRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _ınstructorService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
