using Business.Abstract;
using Business.DTOs.LessonLanguages;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonLanguagesController : ControllerBase
{
    ILessonLanguageService _lessonLanguageService;

    public LessonLanguagesController(ILessonLanguageService lessonLanguageService)
    {
        _lessonLanguageService = lessonLanguageService;
    }

    [HttpPost()]
    public async Task<IActionResult> Add([FromBody] CreateLessonLanguageRequest createLessonLanguageRequest)
    {

        var result = await _lessonLanguageService.Add(createLessonLanguageRequest);

        return Ok(result);
    }

    [HttpPut()]
    public async Task<IActionResult> Update([FromBody] UpdateLessonLanguageRequest updateLessonLanguageRequest)
    {

        var result = await _lessonLanguageService.Update(updateLessonLanguageRequest);

        return Ok(result);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete([FromBody] DeleteLessonLanguageRequest deleteLessonLanguageRequest)
    {

        var result = await _lessonLanguageService.Delete(deleteLessonLanguageRequest);

        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonLanguageService.GetListAsync(pageRequest);
        return Ok(result);
    }
}
