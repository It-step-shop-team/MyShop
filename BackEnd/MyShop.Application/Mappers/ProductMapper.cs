using MyShop.Application.DTOs;
using MyShop.Application.Endpoints.dto;
using MyShop.Domain.Entities;
using MyShop.Domain.BaseEntities;

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
                Category = (CategoryType)dto.CategoryId,
                Tags = dto.Tags,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Converts a Product entity to a PublicProductDto for client response
        /// </summary>
        /// <param name="databaseObject">The Product entity from database</param>
        /// <returns>PublicProductDto for client response</returns>
        public static PublicProductDto ToDto(Product databaseObject)
        {
            return new PublicProductDto
            {
                Id = databaseObject.Id,
                Name = databaseObject.Name,
                Description = databaseObject.Description,
                Price = databaseObject.Price,
                StockQuantity = databaseObject.StockQuantity,
                Category = databaseObject.Category.ToString(),
                ImageUrl = databaseObject.ImageUrl,
                Tags = databaseObject.Tags?.Select(t => t.ToString()).ToList() ?? new List<string>(),
                CreatedAt = databaseObject.CreatedDate,
                UpdatedAt = databaseObject.UpdatedDate
            };
        }

        /// <summary>
        /// Converts a Product entity to a ShortPublicProductDto for client response
        /// </summary>
        /// <param name="databaseObject">The Product entity from database</param>
        /// <returns>ShortPublicProductDto for client response</returns>
        public static ShortPublicProductDto ToShortDto(Product databaseObject)
        {
            return new ShortPublicProductDto
            {
                Id = databaseObject.Id,
                Name = databaseObject.Name,
                Price = databaseObject.Price,
                ImageUrl = databaseObject.ImageUrl,
                CategoryName = databaseObject.Category.ToString()
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
