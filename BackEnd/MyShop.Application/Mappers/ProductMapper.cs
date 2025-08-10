using MyShop.Application.DTOs;
using MyShop.Application.Endpoints.dto;
using MyShop.Domain.Entities;

namespace MyShop.Application.Mappers
{
    public static class ProductMapper
    {
        public static ShortPublicProductDto ToShortPublicProductDto(Product product)
        {
            return new ShortPublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.ToString()
            };
        }

        public static PublicProductDto ToPublicProductDto(Product product)
        {
            return new PublicProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category.ToString(),
                ImageUrl = product.ImageUrl,
                Tags = product.Tags?.Select(t => t.ToString()).ToList() ?? new List<string>(),
                CreatedAt = product.CreatedDate,
                UpdatedAt = product.UpdatedDate
            };
        }

        public static List<ShortPublicProductDto> ToShortPublicProductDtoList(List<Product> products)
        {
            return products.Select(ToShortPublicProductDto).ToList();
        }

        public static List<PublicProductDto> ToPublicProductDtoList(List<Product> products)
        {
            return products.Select(ToPublicProductDto).ToList();
        }
    }
}
