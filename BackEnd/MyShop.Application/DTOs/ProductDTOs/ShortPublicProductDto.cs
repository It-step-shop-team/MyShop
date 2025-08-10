namespace MyShop.Application.Endpoints.dto
{
    public class ShortPublicProductDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required decimal Price { get; init; }
        public required string ImageUrl { get; init; }
        public required string CategoryName { get; init; }
    }
}
