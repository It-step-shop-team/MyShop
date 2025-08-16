using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Mappers;
using MyShop.Application.Common.Errors;
using MyShop.Domain.IRepositories;
using ErrorOr;

namespace MyShop.Application.Services
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork): IProductService
    {
        public async Task<ErrorOr<PublicProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
                var product = ProductMapper.ToDatabaseObject(createProductDto);
                
                var result = await productRepository.AddAsync(product);

                if (result is null)
                    return ErrorTypes.Conflict.CreateProduct;
                
                await unitOfWork.SaveChangesAsync();

                return ProductMapper.ToDto(result);
        }

        public async Task<ErrorOr<PublicProductDto>> GetProductByIdAsync(Guid productId)
        {
            var result = await productRepository.GetByIdAsync(productId);
            if (result is null)
                return ErrorTypes.NotFound.ProductNotFound;

            return ProductMapper.ToDto(result);
        }

        public async Task<ErrorOr<IEnumerable<PublicProductDto>>> GetAllProductsAsync()
        {
            var products = (await productRepository.GetAllAsync());
            if (products is null)
                return ErrorTypes.NotFound.ProductsNotFound;

            var result = products.ToList();
            
            if (!result.Any())
                return ErrorTypes.NotFound.ProductsNotFound;
            
            return ProductMapper.ToDtoList(result);
        }

        public async Task<ErrorOr<PublicProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await productRepository.GetByIdAsync(updateProductDto.Id);
            if (product is null)
                return ErrorTypes.NotFound.ProductNotFound;

            // Handle nullable properties appropriately
            if (updateProductDto.Name != null)
                product.Name = updateProductDto.Name;
            if (updateProductDto.Description != null)
                product.Description = updateProductDto.Description;
            if (updateProductDto.Price != null)
                product.Price = updateProductDto.Price.Value;
            if (updateProductDto.StockQuantity != null)
                product.StockQuantity = updateProductDto.StockQuantity.Value;
            if (updateProductDto.ImageUrl != null)
                product.ImageUrl = updateProductDto.ImageUrl;
            if (updateProductDto.CategoryId != null)
                product.CategoryId = updateProductDto.CategoryId.Value;
            
            product.UpdatedDate = DateTime.UtcNow;
            
            var result =  await productRepository.UpdateAsync(product);
            
            if (result is  null)
                return ErrorTypes.Conflict.UpdateProduct;
            
            await unitOfWork.SaveChangesAsync();

            return ProductMapper.ToDto(product);
        }

        public async Task<ErrorOr<bool>> DeleteProductAsync(Guid productId)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product == null)
                return ErrorTypes.NotFound.ProductNotFound;

            var result = await productRepository.DeleteAsync(productId);
            if (result == false)
                return result;
                    
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
