using Business.Abstract;
using Business.Dtos.Requests;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        INotificationService _announcementService;

        public AnnouncementsController(INotificationService announcementService)
        {
            _announcementService=announcementService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateNotificationRequest createAnnouncementRequest)
        {

            var result = await _announcementService.Add(createAnnouncementRequest);

            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateNotificationRequest updateAnnouncementRequest)
        {

            var result = await _announcementService.Update(updateAnnouncementRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteNotificationRequest deleteAnnouncementRequest)
        {

            var result = await _announcementService.Delete(deleteAnnouncementRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _announcementService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
