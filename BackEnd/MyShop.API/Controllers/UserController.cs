using Microsoft.AspNetCore.Mvc;
using MyShop.API.Extensions;
using MyShop.Application.DTOs.UserDTOs;
using MyShop.Application.Interfaces;

namespace MyShop.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        var result = await userService.Register(registerRequestDto);
        return result.GetIActionResult();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var result = await userService.Login(loginRequestDto);
        return result.GetIActionResult();
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto refreshRequestDto)
    {
        var result = await userService.Refresh(refreshRequestDto);
        return result.GetIActionResult();
    }
}