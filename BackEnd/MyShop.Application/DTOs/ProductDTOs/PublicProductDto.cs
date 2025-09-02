using MyShop.Domain.BaseEntities;

namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for returning product information
    /// that is safe to expose publicly (e.g., in API responses).
    /// </summary>
    public class PublicProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
