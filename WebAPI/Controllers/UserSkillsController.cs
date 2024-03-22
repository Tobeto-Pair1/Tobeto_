using Business.Abstract;
using Business.DTOs.Requests;
using Core.DataAccess.Paging;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSkillsController : ControllerBase
{

  private readonly  IUserSkillService _userSkillService;

    public UserSkillsController(IUserSkillService userSkillService)
    {
        _userSkillService = userSkillService;
    }

    [HttpPost("add")]

    public async Task<IActionResult> Add([FromBody] CreateUserSkillRequest createUserSkillRequest)
    {
        createUserSkillRequest.UserId = getAuthenticatedUserId();
        var result = await _userSkillService.Add(createUserSkillRequest);

        return Ok(result);
    }
    protected Guid getAuthenticatedUserId()
    {
        Guid userId = HttpContext.User.GetUserId();
        return userId;
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserSkillRequest updateUserSkillRequest)
    {

        var result = await _userSkillService.Update(updateUserSkillRequest);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserSkillRequest deleteUserSkillRequest)
    {


        var result = await _userSkillService.Delete(deleteUserSkillRequest);

        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        var result = await _userSkillService.GetListAsync(pageRequest);

        return Ok(result);
    }
    [HttpGet("getListByUser")]
    public async Task<IActionResult> GetListByUser(Guid id)
    {

        var result = await _userSkillService.GetListByUser(id);

        return Ok(result);
    }
}

