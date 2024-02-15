using Business.Abstract;
using Business.DTOs.BlogsPress;
using Business.DTOs.ContactInformations;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationsController : ControllerBase
    {
        IContactInformationService _contactInformationService;

        public ContactInformationsController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateContactInformationRequest createContactInformationRequest)
        {

            var result = await _contactInformationService.Add(createContactInformationRequest);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateContactInformationRequest updateContactInformationRequest)
        {

            var result = await _contactInformationService.Update(updateContactInformationRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteContactInformationRequest deleteContactInformationRequest)
        {

            var result = await _contactInformationService.Delete(deleteContactInformationRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _contactInformationService.GetListAsync(pageRequest);
            return Ok(result);
        }

    }
}
