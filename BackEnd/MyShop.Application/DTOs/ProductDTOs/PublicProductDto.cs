using MyShop.Application.DTOs.TagDTOs;

namespace MyShop.Application.DTOs.ProductDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for returning product information
    /// that is safe to expose publicly (e.g., in API responses).
    /// </summary>
    public class PublicProductDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public required Guid CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Guid> TagsId { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
