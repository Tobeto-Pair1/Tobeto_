using Business.Abstract;
using Business.DTOs.Experiences;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExperiencesController : ControllerBase
{
    IExperienceService _experienceService;

    public ExperiencesController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateExperienceRequest createExperienceRequest)
    {
        var result = await _experienceService.Add(createExperienceRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateExperienceRequest updateExperienceRequest)
    {
        var result = await _experienceService.Update(updateExperienceRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteExperienceRequest deleteExperienceRequest)
    {
        var result = await _experienceService.Delete(deleteExperienceRequest);
        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _experienceService.GetListAsync(pageRequest);
        return Ok(result);
    }

    
    [HttpGet("getListByUser")]
    public async Task<IActionResult> GetListByUser(Guid id)
    {
        var result = await _experienceService.GetListByUser(id);
        return Ok(result);
    }
}
