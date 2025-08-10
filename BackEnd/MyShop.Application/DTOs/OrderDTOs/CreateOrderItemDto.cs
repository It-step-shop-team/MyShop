namespace MyShop.Application.DTOs
{
    public class CreateOrderItemDto
    {
        public required Guid ProductId { get; init; }
        public required int Quantity { get; init; }
        public required decimal Price { get; init; }
    }
}
