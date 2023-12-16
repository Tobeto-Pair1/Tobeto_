using Business.Abstract;
using Business.Dtos.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguagesController : ControllerBase
    {
        ILanguageService _languageService;

        public ForeignLanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateLanguageRequest createLanguageRequest)
        {

            var result = await _languageService.Add(createLanguageRequest);

            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageRequest deleteLanguageRequest)
        {
            var result = await _languageService.Delete(deleteLanguageRequest);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageRequest updateLanguageRequest)
        {
            var result = await _languageService.Update(updateLanguageRequest);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _languageService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

