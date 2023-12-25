using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {

        IProgramService _programService;

        public ProgramsController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateProgramRequest createProgramRequest)
        {

            var result = await _programService.Add(createProgramRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramRequest updateProgramRequest)
        {

            var result = await _programService.Update(updateProgramRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramRequest deleteProgramRequest)
        {


            var result = await _programService.Delete(deleteProgramRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _programService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
