using Business.Abstract;
using Business.Dtos.UserOperationClaims;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : ControllerBase
{
    private readonly IUserOperationClaimService _userOperationClaimService;

    public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
    {
        _userOperationClaimService = userOperationClaimService;
    }
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimRequest createUserOperationClaimRequest)
    {
        await _userOperationClaimService.Add(createUserOperationClaimRequest);
        return Ok(createUserOperationClaimRequest);
    }


    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
    {
        await _userOperationClaimService.Delete(deleteUserOperationClaimRequest);
        return Ok();
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
    {
        var result  = await _userOperationClaimService.Update(updateUserOperationClaimRequest);
        return Ok(result);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _userOperationClaimService.GetListAsync(pageRequest);
        return Ok(result);
    }
}
