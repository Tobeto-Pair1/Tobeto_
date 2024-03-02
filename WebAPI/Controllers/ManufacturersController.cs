using Business.Abstract;
using Business.DTOs.Manufacturers;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerervice)
        {
            _manufacturerService = manufacturerervice;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateManufacturerRequest createManufacturerRequest)
        {

            var result = await _manufacturerService.Add(createManufacturerRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateManufacturerRequest updateManufacturerRequest)
        {

            var result = await _manufacturerService.Update(updateManufacturerRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteManufacturerRequest deleteManufacturerRequest)
        {


            var result = await _manufacturerService.Delete(deleteManufacturerRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _manufacturerService.GetListAsync(pageRequest);

            return Ok(result);
        }
    }
}
