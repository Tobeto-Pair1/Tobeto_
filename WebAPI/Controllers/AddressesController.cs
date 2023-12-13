using Business.Abstract;
using Business.DTOs.Request;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
           _addressService = addressService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateAddressRequest createAddressRequest)
        {

            var result = await _addressService.Add(createAddressRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressRequest updateAddressRequest)
        {

            var result = await _addressService.Update(updateAddressRequest);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressRequest deleteAddressRequest)
        {

            var result = await _addressService.Delete(deleteAddressRequest);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _addressService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

