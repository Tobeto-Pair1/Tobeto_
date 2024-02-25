using Business.Abstract;
using Business.DTOs.Towns;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class TownController : Controller
{
    ITownService _townService;

    public TownController(ITownService townService)
    {
        _townService = townService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateTownRequest createTownRequest)
    {

        var result = await _townService.Add(createTownRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteTownRequest deleteTownRequest)
    {
        var result = await _townService.Delete(deleteTownRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateTownRequest updateTownRequest)
    {
        var result = await _townService.Update(updateTownRequest);
        return Ok(result);
    }

    [HttpGet("getlist")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _townService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("getListByCity")]
    public async Task<IActionResult> GetListByCity(Guid id)
    {
        var result = await _townService.GetListByCity(id);
        return Ok(result);
    }

}

