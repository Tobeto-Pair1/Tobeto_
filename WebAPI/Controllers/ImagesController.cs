using Business.Abstract;
using Business.DTOs.Image;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("add")]

    public async Task<IActionResult> Add([FromForm] CreateImageRequest createImageRequest)
    {

        var result = await _imageService.Add(createImageRequest);

        return Ok(result);
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromForm] UpdateImageRequest updateImageRequest)
    {

        var result = await _imageService.Update(updateImageRequest);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromForm] DeleteImageRequest deleteImageRequest)
    {

        var result = await _imageService.Delete(deleteImageRequest);

        return Ok(result);
    }
    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _imageService.GetListAsync(pageRequest);
        return Ok(result);
    }

}
