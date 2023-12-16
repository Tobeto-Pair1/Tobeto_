using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TownController : Controller
    {
        ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTownRequest createTownRequest)
        {

            var result = await _townService.Add(createTownRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTownRequest deleteTownRequest)
        {
            var result = await _townService.Delete(deleteTownRequest);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTownRequest updateTownRequest)
        {
            var result = await _townService.Update(updateTownRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _townService.GetListAsync(pageRequest);
            return Ok(result);
        }


      
    }
}

