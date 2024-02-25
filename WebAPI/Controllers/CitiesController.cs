using Business.Abstract;
using Business.DTOs.Cities;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost("add")]

    public async Task<IActionResult> Add([FromBody] CreateCityRequest createCityRequest)
    {
        var result = await _cityService.Add(createCityRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCityRequest updateCityRequest)
    {
        var result = await _cityService.Update(updateCityRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCityRequest deleteCityRequest)
    {
        var result = await _cityService.Delete(deleteCityRequest);
        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _cityService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("getListByCountry")]
    public async Task<IActionResult> GetListByCountry(Guid id)
    {
        var result = await _cityService.GetListByCountry(id);
        return Ok(result);
    }
}
