using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Mappers;
using MyShop.Application.Common.Errors;
using MyShop.Domain.IRepositories;
using MyShop.Domain.Entities;
using ErrorOr;

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

        public async Task<ErrorOr<PublicProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                var product = ProductMapper.ToDatabaseObject(createProductDto);
                
                await _productRepository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                return ProductMapper.ToDto(product);
            }
            catch (Exception ex)
            {
                return ErrorTypes.Validation.InvalidProductData;
            }
        }

        public async Task<ErrorOr<PublicProductDto>> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                return ErrorTypes.NotFound.ProductNotFound;
            }

            return ProductMapper.ToDto(product);
        }

        public async Task<ErrorOr<IEnumerable<PublicProductDto>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if (products == null || !products.Any())
            {
                return Enumerable.Empty<PublicProductDto>().ToList();
            }

            return ProductMapper.ToDtoList(products);
        }

        public async Task<ErrorOr<PublicProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(updateProductDto.Id);
            if (product == null)
            {
                return ErrorTypes.NotFound.ProductNotFound;
            }

            // Handle nullable properties appropriately
            if (updateProductDto.Name != null)
                product.Name = updateProductDto.Name;
            if (updateProductDto.Description != null)
                product.Description = updateProductDto.Description;
            if (updateProductDto.Price.HasValue)
                product.Price = updateProductDto.Price.Value;
            if (updateProductDto.StockQuantity.HasValue)
                product.StockQuantity = updateProductDto.StockQuantity.Value;
            if (updateProductDto.ImageUrl != null)
                product.ImageUrl = updateProductDto.ImageUrl;
            if (updateProductDto.CategoryId.HasValue)
            {
                // TODO: Map Guid CategoryId to CategoryType enum properly
                // For now, skipping assignment or throw error
            }
            
            product.UpdatedDate = DateTime.UtcNow;

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return ProductMapper.ToDto(product);
        }

        public async Task<ErrorOr<bool>> DeleteProductAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                return ErrorTypes.NotFound.ProductNotFound;
            }

            var result = await _productRepository.DeleteAsync(productId);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return result;
        }
    }
}
