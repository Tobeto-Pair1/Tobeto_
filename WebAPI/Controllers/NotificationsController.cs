using Business.Abstract;
using Business.DTOs.Notifications;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateNotificationRequest createNotificationRequest)
        {

            var result = await _notificationService.Add(createNotificationRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateNotificationRequest updateNotificationRequest)
        {

            var result = await _notificationService.Update(updateNotificationRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteNotificationRequest deleteNotificationRequest)
        {

            var result = await _notificationService.Delete(deleteNotificationRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _notificationService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
