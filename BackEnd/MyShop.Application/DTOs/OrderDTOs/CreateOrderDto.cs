namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for creating a new order.
    /// </summary>
    public class CreateOrderDto
    {
        /// <summary>
        /// The unique identifier of the user who is placing the order.
        /// </summary>
        public required Guid UserId { get; init; }

        /// <summary>
        /// The total amount of the order, including all items and possible discounts.
        /// </summary>
        public required decimal TotalAmount { get; init; }

        /// <summary>
        /// The shipping address where the order should be delivered.
        /// </summary>
        public required string ShippingAddress { get; init; }

        /// <summary>
        /// The collection of items included in the order.
        /// Each item is described by <see cref="CreateOrderItemDto"/>.
        /// </summary>
        public required ICollection<CreateOrderItemDto> OrderItems { get; init; }
    }
}
