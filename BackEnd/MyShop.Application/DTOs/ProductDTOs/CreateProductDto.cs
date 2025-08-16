using MyShop.Domain.BaseEntities;

namespace MyShop.Application.DTOs
{
    public class CreateProductDto
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required decimal Price { get; init; }
        public required int StockQuantity { get; init; }
        public required Guid CategoryId { get; init; }
        public required string ImageUrl { get; init; }
        public required List<Tag> Tags { get; init; }
    }
}
