using MyShop.Application.DTOs;
using MyShop.Application.Endpoints.dto;
using MyShop.Domain.Entities;

namespace MyShop.Application.Mappers
{
    public static class ProductMapper
    {
        /// <summary>
        /// Converts a CreateProductDto to a Product entity for database storage
        /// </summary>
        /// <param name="dto">The CreateProductDto to convert</param>
        /// <returns>Product entity ready for database storage</returns>
        public static Product ToDatabaseObject(CreateProductDto dto)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                Tags = dto.Tags,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Converts a Product entity to a PublicProductDto for client response
        /// </summary>
        /// <param name="product">The Product entity from database</param>
        /// <returns>PublicProductDto for client response</returns>
        public static PublicProductDto ToDto(Product product)
        {
            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category?.Name,
                ImageUrl = product.ImageUrl,
                Tags = product.Tags?.Select(t => t.Name).ToList(),
                CreatedAt = product.CreatedDate,
                UpdatedAt = product.UpdatedDate
            };
        }

        /// <summary>
        /// Converts a Product entity to a ShortPublicProductDto for client response
        /// </summary>
        /// <param name="product">The Product entity from database</param>
        /// <returns>ShortPublicProductDto for client response</returns>
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
        /// Converts a list of Product entities to a list of PublicProductDto
        /// </summary>
        /// <param name="databaseObjects">List of Product entities</param>
        /// <returns>List of PublicProductDto</returns>
        public static List<PublicProductDto> ToDtoList(IEnumerable<Product> databaseObjects)
        {
            return databaseObjects.Select(ToDto).ToList();
        }

        /// <summary>
        /// Converts a list of Product entities to a list of ShortPublicProductDto
        /// </summary>
        /// <param name="databaseObjects">List of Product entities</param>
        /// <returns>List of ShortPublicProductDto</returns>
        public static List<ShortPublicProductDto> ToShortDtoList(IEnumerable<Product> databaseObjects)
        {
            return databaseObjects.Select(ToShortDto).ToList();
        }
    }
}
