using Business.Abstract;
using Business.DTOs.CourseType;
using Business.DTOs.Homeworks;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CourseTypeController : ControllerBase
{

    private readonly ICourseTypeService courseTypeService;

    public CourseTypeController(ICourseTypeService courseTypeService)
    {
       this.courseTypeService= courseTypeService;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseTypeRequest createCourseTypeRequest)
    {

        var result = await courseTypeService.Add(createCourseTypeRequest);

        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseTypeRequest updateCourseTypeRequest)
    {

        var result = await courseTypeService.Update(updateCourseTypeRequest);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCourseTypeRequest deleteCourseTypeRequest)
    {

        var result = await courseTypeService.Delete(deleteCourseTypeRequest);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await courseTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }






}
