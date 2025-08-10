using MyShop.Application.DTOs;
using ErrorOr;

namespace MyShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ErrorOr<PublicProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<ErrorOr<PublicProductDto>> GetProductByIdAsync(Guid productId);
        Task<ErrorOr<IEnumerable<PublicProductDto>>> GetAllProductsAsync();
        Task<ErrorOr<PublicProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ErrorOr<bool>> DeleteProductAsync(Guid productId);
    }
}
