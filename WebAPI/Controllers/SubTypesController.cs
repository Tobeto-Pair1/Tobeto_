using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTypesController : ControllerBase
    {
        ISubTypeService _subTypeService;

        public SubTypesController(ISubTypeService subTypeService)
        {
            _subTypeService = subTypeService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateSubTypeRequest createSubTypeRequest)
        {

            var result = await _subTypeService.Add(createSubTypeRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSubTypeRequest updateSubTypeRequest)
        {

            var result = await _subTypeService.Update(updateSubTypeRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSubTypeRequest deleteSubTypeRequest)
        {


            var result = await _subTypeService.Delete(deleteSubTypeRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _subTypeService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
