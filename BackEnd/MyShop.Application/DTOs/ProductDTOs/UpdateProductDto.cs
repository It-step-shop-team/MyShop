namespace MyShop.Application.DTOs
{
    public class UpdateProductDto
    {
        public required Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public decimal? Price { get; init; }
        public int? StockQuantity { get; init; }
        public string? ImageUrl { get; init; }
        public Guid? CategoryId { get; init; }
    }
}
