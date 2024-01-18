using Business.Abstract;
using Business.DTOs.Country;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCountryRequest createCountryRequest)
        {
            await _countryService.Add(createCountryRequest);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCountryRequest deleteCountryRequest)
        {
            await _countryService.Delete(deleteCountryRequest);
            return Ok();

        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _countryService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCountryRequest updateCountryRequest)
        {
            await _countryService.Update(updateCountryRequest);
            return Ok();

        }
    }
}
