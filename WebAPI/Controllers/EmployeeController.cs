using Business.Abstract;
using Business.DTOs.Employees;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateEmployeeRequest createEmployeeRequest)
        {

            var result = await _employeeService.Add(createEmployeeRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest updateEmployeeRequest)
        {

            var result = await _employeeService.Update(updateEmployeeRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeRequest deleteEmployeeRequest)
        {

            var result = await _employeeService.Delete(deleteEmployeeRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _employeeService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
