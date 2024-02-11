using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.BlogsPress;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsPressController : ControllerBase
{
    IBlogPressService _blogPressService;
    
    public BlogsPressController(IBlogPressService blogPressService)
    {
        _blogPressService = blogPressService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateBlogPressRequest createBlogPressRequest)
    {

        var result = await _blogPressService.Add(createBlogPressRequest);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateBlogPressRequest updateBlogPressRequest)
    {

        var result = await _blogPressService.Update(updateBlogPressRequest);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBlogPressRequest deleteBlogPressRequest)
    {

        var result = await _blogPressService.Delete(deleteBlogPressRequest);

        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _blogPressService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("getbyId")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var result = await _blogPressService.GetByIdAsync(id);
        return Ok(result);
    }
}
