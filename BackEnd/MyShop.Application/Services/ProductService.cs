using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.IRepositories;
using MyShop.Domain.Entities;


namespace MyShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PublicProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                StockQuantity = createProductDto.StockQuantity,
                ImageUrl = createProductDto.ImageUrl,
                Tags = createProductDto.Tags ,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            };
        }

        public async Task<PublicProductDto?> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            };
        }

        public async Task<IEnumerable<PublicProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if (products == null) return Enumerable.Empty<PublicProductDto>();
            return products.Select(product => new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            });
        }

        public async Task<PublicProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(updateProductDto.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {updateProductDto.Id} not found");
            }

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            };
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var result = await _productRepository.DeleteAsync(productId);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }
    }
}
