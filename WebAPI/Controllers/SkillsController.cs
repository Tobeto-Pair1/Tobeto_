using Business.Abstract;
using Business.DTOs.Skills;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class SkillsController : Controller
{
    ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateSkillRequest createSkillRequest)
    {

        var result = await _skillService.Add(createSkillRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSkillRequest deleteSkillRequest)
    {
        var result = await _skillService.Delete(deleteSkillRequest);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateSkillRequest updateSkillRequest)
    {
        var result = await _skillService.Update(updateSkillRequest);
        return Ok(result);
    }

    [HttpGet("getlist")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _skillService.GetListAsync(pageRequest);
        return Ok(result);
    }
}