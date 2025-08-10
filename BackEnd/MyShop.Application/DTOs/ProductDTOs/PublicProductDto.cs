using MyShop.Domain.BaseEntities;

namespace MyShop.Application.DTOs
{
    public class PublicProductDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required decimal Price { get; init; }
        public required int StockQuantity { get; init; }
        public required string Category { get; init; }
        public required string ImageUrl { get; init; }
        public List<string>? Tags { get; init; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
