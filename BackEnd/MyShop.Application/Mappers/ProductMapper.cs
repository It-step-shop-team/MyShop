using MyShop.Application.DTOs;
using MyShop.Application.DTOs.ProductDTOs;
using MyShop.Application.Endpoints.dto;
using MyShop.Domain.Entities;

namespace MyShop.Application.Mappers
{
    /// <summary>
    /// Provides mapping functions to convert between Product entities and DTOs.
    /// </summary>
    public static class ProductMapper
    {
        /// <summary>
        /// Converts a <see cref="CreateProductDto"/> into a <see cref="Product"/> entity 
        /// that can be stored in the database.
        /// </summary>
        /// <param name="dto">The DTO containing product creation data.</param>
        /// <returns>A <see cref="Product"/> entity populated with the given DTO values.</returns>
        public static Product ToDatabaseObject(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow, // Set creation timestamp
                UpdatedAt = DateTime.UtcNow  // Set update timestamp
            };

            // Map associated tags if provided
            if (dto.TagIds != null && dto.TagIds.Any())
            {
                product.ProductTags = dto.TagIds.Select(tagId => new ProductTag
                {
                    ProductId = product.Id,
                    TagId = tagId
                }).ToList();
            }

            return product;
        }

        /// <summary>
        /// Converts a <see cref="Product"/> entity into a <see cref="PublicProductDto"/> 
        /// for external API usage.
        /// </summary>
        /// <param name="product">The product entity to map.</param>
        /// <returns>A <see cref="PublicProductDto"/> containing product details.</returns>
        public static PublicProductDto ToDto(Product product)
        {
            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category?.Name, // Map category name if available
                ImageUrl = product.ImageUrl,
                ProductTags = product.ProductTags.Select(pt => pt.Tag!.Name).ToList(), // Extract tag names
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        /// <summary>
        /// Converts a <see cref="Product"/> entity into a <see cref="ShortPublicProductDto"/> 
        /// with minimal product details (e.g., for product lists).
        /// </summary>
        /// <param name="product">The product entity to map.</param>
        /// <returns>A <see cref="ShortPublicProductDto"/> with essential product details.</returns>
        public static ShortPublicProductDto ToShortDto(Product product)
        {
            return new ShortPublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category?.Name
            };
        }

        /// <summary>
        /// Maps a collection of <see cref="Product"/> entities to a list of <see cref="PublicProductDto"/>.
        /// </summary>
        /// <param name="databaseObjects">The collection of product entities.</param>
        /// <returns>A list of <see cref="PublicProductDto"/>.</returns>
        public static List<PublicProductDto> ToDtoList(IEnumerable<Product> databaseObjects)
        {
            return databaseObjects.Select(ToDto).ToList();
        }

        /// <summary>
        /// Maps a collection of <see cref="Product"/> entities to a list of <see cref="ShortPublicProductDto"/>.
        /// </summary>
        /// <param name="databaseObjects">The collection of product entities.</param>
        /// <returns>A list of <see cref="ShortPublicProductDto"/>.</returns>
        public static List<ShortPublicProductDto> ToShortDtoList(IEnumerable<Product> databaseObjects)
        {
            return databaseObjects.Select(ToShortDto).ToList();
        }
    }
}
