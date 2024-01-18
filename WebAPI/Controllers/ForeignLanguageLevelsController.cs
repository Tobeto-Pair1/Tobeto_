using Business.Abstract;
using Business.DTOs.ForeignLanguageLevels;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguageLevelsController : ControllerBase
    {
        IForeignLanguageLevelService _languageLevelService;
        
        public ForeignLanguageLevelsController(IForeignLanguageLevelService languageLevelService)
        {
            _languageLevelService = languageLevelService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateForeignLanguageLevelRequest createLanguageLevelRequest)
        {

            var result = await _languageLevelService.Add(createLanguageLevelRequest);

            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteForeignLanguageLevelRequest deleteLanguageLevelRequest)
        {
            var result = await _languageLevelService.Delete(deleteLanguageLevelRequest);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateForeignLanguageLevelRequest updateLanguageLevelRequest)
        {
            var result = await _languageLevelService.Update(updateLanguageLevelRequest);

            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _languageLevelService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
