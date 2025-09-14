using Microsoft.AspNetCore.Mvc;
using MyShop.API.Extensions;
using MyShop.Application.DTOs.ProductDTOs;
using MyShop.Application.Interfaces;

namespace MyShop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController(IProductService productService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productsResult = await productService.GetAllProductsAsync();

            return productsResult.GetIActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var productResult = await productService.GetProductByIdAsync(id);
            
            return productResult.GetIActionResult();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productResult = await productService.CreateProductAsync(createProductDto);
            
            return productResult.GetIActionResult();

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productResult = await productService.UpdateProductAsync(updateProductDto);
            
            return productResult.GetIActionResult();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await productService.DeleteProductAsync(id);

            return result.GetIActionResult();
        }
    }
}
