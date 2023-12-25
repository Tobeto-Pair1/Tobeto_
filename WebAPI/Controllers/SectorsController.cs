using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.DTOs.Sectors;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SectorsController : Controller
    {
        ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSectorRequest createSectorRequest)
        {

            var result = await _sectorService.Add(createSectorRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSectorRequest deleteSectorRequest)
        {
            var result = await _sectorService.Delete(deleteSectorRequest);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSectorRequest updateSectorRequest)
        {
            var result = await _sectorService.Update(updateSectorRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _sectorService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}

