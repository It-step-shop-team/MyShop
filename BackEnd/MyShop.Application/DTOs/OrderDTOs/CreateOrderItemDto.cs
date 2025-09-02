namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a single item
    /// within an order during order creation.
    /// </summary>
    public class CreateOrderItemDto
    {
        /// <summary>
        /// The unique identifier of the product being ordered.
        /// </summary>
        public required Guid ProductId { get; init; }

        /// <summary>
        /// The quantity of the specified product in the order.
        /// </summary>
        public required int Quantity { get; init; }

        /// <summary>
        /// The price of a single unit of the product at the time of ordering.
        /// </summary>
        public required decimal Price { get; init; }
    }
}
