using Microsoft.AspNetCore.Mvc;
using MyShop.API.Extensions;
using MyShop.Application.Interfaces;

namespace MyShop.API.Controllers;

[ApiController]
[Route("api/tag")]

public class TagController(ITagService tagService) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllOrders() 
    {
        var result = await tagService.GetAllTagsAsync(); 
        return result.GetIActionResult();
    }
}