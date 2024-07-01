using FinancialRevenues.Users.Dtos;
using FinancialRevenues.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRevenues.Users.Controllers;
public class UserController(IUserService userService) : Controller
{
    [HttpGet("GetUser")]
    public async Task<ActionResult<GetUserForViewDto>> GetUser([FromQuery]long Id)
    {
        return Ok(await userService.GetAsync(Id));
    }
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateOrEditUserDto input)
    {
        await userService.AddAsync(input);
        return Ok();
    }
    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordInput input)
    {
        await userService.ChangePasswordAsync(input);
        return Ok();
    }
}