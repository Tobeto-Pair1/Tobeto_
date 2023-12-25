using Business.Abstract;
using Business.DTOs.SocialMedias;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaRequest createSocialMediaRequest)
        {
            await _socialMediaService.Add(createSocialMediaRequest);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaRequest deleteSocialMediaRequest)
        {
            await _socialMediaService.Delete(deleteSocialMediaRequest);
            return Ok();
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _socialMediaService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
