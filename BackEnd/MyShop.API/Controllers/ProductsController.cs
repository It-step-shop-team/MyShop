using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using ErrorOr;

namespace MyShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicProductDto>>> GetAllProducts()
        {
            var productsResult = await _productService.GetAllProductsAsync();
            
            return productsResult.Match<ActionResult<IEnumerable<PublicProductDto>>>(
                products => Ok(products),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicProductDto>> GetProductById(Guid id)
        {
            var productResult = await _productService.GetProductByIdAsync(id);
            
            return productResult.Match<ActionResult<PublicProductDto>>(
                product => Ok(product),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpPost]
        public async Task<ActionResult<PublicProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productResult = await _productService.CreateProductAsync(createProductDto);
            
            return productResult.Match<ActionResult<PublicProductDto>>(
                product => CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != updateProductDto.Id)
                return BadRequest("ID mismatch");

            var productResult = await _productService.UpdateProductAsync(updateProductDto);
            
            return productResult.Match<IActionResult>(
                product => Ok(product),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);
            
            return result.Match<IActionResult>(
                success => success ? NoContent() : NotFound(),
                errors => Problem(errors.First().Description)
            );
        }
    }
}
