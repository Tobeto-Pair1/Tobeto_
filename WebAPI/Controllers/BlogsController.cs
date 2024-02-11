using Business.Abstract;
using Business.DTOs.Addresses;
using Business.DTOs.Blogs;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateBlogRequest createBlogRequest)
    {

        var result = await _blogService.Add(createBlogRequest);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateBlogRequest updateBlogRequest)
    {

        var result = await _blogService.Update(updateBlogRequest);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBlogRequest deleteBlogRequest)
    {

        var result = await _blogService.Delete(deleteBlogRequest);

        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _blogService.GetListAsync(pageRequest);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _blogService.GetByIdAsync(id);
        return Ok(result);
    }
}
