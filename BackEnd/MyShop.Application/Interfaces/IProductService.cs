using MyShop.Application.DTOs;
using MyShop.Domain.Entities;

namespace MyShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<PublicProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<PublicProductDto?> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<PublicProductDto>> GetAllProductsAsync();
        Task<PublicProductDto> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
