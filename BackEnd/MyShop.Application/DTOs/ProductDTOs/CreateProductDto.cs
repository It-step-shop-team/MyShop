using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for creating a new product.
    /// </summary>
    public class CreateProductDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid>? TagIds { get; set; }
    }
}
