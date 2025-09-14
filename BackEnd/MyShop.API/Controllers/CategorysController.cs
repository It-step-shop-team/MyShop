using Microsoft.AspNetCore.Mvc;
using MyShop.API.Extensions;
using MyShop.Application.Interfaces;

namespace MyShop.API.Controllers;

[ApiController]
[Route("api/category")]
public class CategorysController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var result = await categoryService.GetAllCategoriesAsync();
        return result.GetIActionResult();
    }
}