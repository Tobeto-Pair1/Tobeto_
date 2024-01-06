using Business.Abstract;
using Business.DTOs.ForeignLanguages;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguagesController : ControllerBase
    {
        IForeignLanguageService _languageService;

        public ForeignLanguagesController(IForeignLanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateForeignLanguageRequest createLanguageRequest)
        {

            var result = await _languageService.Add(createLanguageRequest);

            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteForeignLanguageRequest deleteLanguageRequest)
        {
            var result = await _languageService.Delete(deleteLanguageRequest);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateForeignLanguageRequest updateLanguageRequest)
        {
            var result = await _languageService.Update(updateLanguageRequest);

            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _languageService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

