using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Mappers;
using MyShop.Application.Common.Errors;
using MyShop.Domain.IRepositories;
using ErrorOr;
using MyShop.Application.DTOs.ProductDTOs;

namespace MyShop.Application.Services
{
    /// <summary>
    /// Service responsible for handling product-related operations such as
    /// creating, retrieving, updating, and deleting products.
    /// </summary>
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
    {
        /// <summary>
        /// Creates a new product in the system.
        /// </summary>
        /// <param name="createProductDto">DTO containing product creation data.</param>
        /// <returns>
        /// <see cref="PublicProductDto"/> if creation succeeds, 
        /// or an <see cref="ErrorOr{T}"/> error if creation fails.
        /// </returns>
        public async Task<ErrorOr<PublicProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = ProductMapper.ToDatabaseObject(createProductDto);

            var result = await productRepository.AddAsync(product);

            if (result is null)
                return ErrorTypes.Conflict.CreateProduct;

            await unitOfWork.SaveChangesAsync();

            return ProductMapper.ToDto(result);
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>
        /// <see cref="PublicProductDto"/> if found, 
        /// or <see cref="ErrorTypes.NotFound.ProductNotFound"/> if no product exists with the given ID.
        /// </returns>
        public async Task<ErrorOr<PublicProductDto>> GetProductByIdAsync(Guid productId)
        {
            var result = await productRepository.GetByIdAsync(productId);
            if (result is null)
                return ErrorTypes.NotFound.ProductNotFound;

            return ProductMapper.ToDto(result);
        }

        /// <summary>
        /// Retrieves all available products in the system.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="PublicProductDto"/> if products exist,
        /// or <see cref="ErrorTypes.NotFound.ProductsNotFound"/> if none are found.
        /// </returns>
        public async Task<ErrorOr<IEnumerable<PublicProductDto>>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            if (!products.Any())
                return ErrorTypes.NotFound.ProductsNotFound;

            var result = products.ToList();

            if (!result.Any())
                return ErrorTypes.NotFound.ProductsNotFound;

            return ProductMapper.ToDtoList(result);
        }

        /// <summary>
        /// Updates an existing product using the provided data.
        /// </summary>
        /// <param name="updateProductDto">DTO containing updated product values.</param>
        /// <returns>
        /// Updated <see cref="PublicProductDto"/> if successful,
        /// or an error if the product was not found or the update failed.
        /// </returns>
        public async Task<ErrorOr<PublicProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await productRepository.GetByIdAsync(updateProductDto.Id);
            if (product is null)
                return ErrorTypes.NotFound.ProductNotFound;

            // Apply only non-null updates to the product
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

            product.UpdatedAt = DateTime.UtcNow; // Track update timestamp

            var result = await productRepository.UpdateAsync(product);

            if (result is null)
                return ErrorTypes.Conflict.UpdateProduct;

            await unitOfWork.SaveChangesAsync();

            return ProductMapper.ToDto(product);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>
        /// True if deletion succeeded, or an error if the product was not found or deletion failed.
        /// </returns>
        public async Task<ErrorOr<PublicProductDto>> DeleteProductAsync(Guid productId)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product == null)
                return ErrorTypes.NotFound.ProductNotFound;

            var result = await productRepository.DeleteAsync(productId);
            if (result is null)
                return Error.Validation(code: "ProductValidation", description: "Product not found.");

            await unitOfWork.SaveChangesAsync();
            return ProductMapper.ToDto(result);
        }
    }
}
