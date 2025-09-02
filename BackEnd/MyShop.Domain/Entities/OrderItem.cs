namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Entity representing an item within a customer order.
    /// Contains information about the product, quantity, and price.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Unique identifier of the order item.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Identifier of the associated order.
        /// </summary>
        public required Guid OrderId { get; set; }

        /// <summary>
        /// Navigation property to the associated order.
        /// Optional for lazy loading.
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// Identifier of the associated product.
        /// </summary>
        public required Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property to the associated product.
        /// Optional for lazy loading.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Quantity of the product in the order.
        /// </summary>
        public required int Quantity { get; set; }

        /// <summary>
        /// Price of a single unit of the product at the time of the order.
        /// </summary>
        public required decimal Price { get; set; }
    }
}
