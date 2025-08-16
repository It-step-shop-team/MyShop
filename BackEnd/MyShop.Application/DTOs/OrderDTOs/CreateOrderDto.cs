namespace MyShop.Application.DTOs
{
    public class CreateOrderDto
    {
        public required Guid UserId { get; init; }
        public required decimal TotalAmount { get; init; }
        public required string ShippingAddress { get; init; }
        public required List<CreateOrderItemDto> OrderItems { get; init; }
    }
}
