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
    public class CompaniesController : ControllerBase
    {
        ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCompanyRequest createCompanyRequest)
        {
            await _companyService.Add(createCompanyRequest);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCompanyRequest deleteCompanyRequest)
        {
            await _companyService.Delete(deleteCompanyRequest);
            return Ok();

        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _companyService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
