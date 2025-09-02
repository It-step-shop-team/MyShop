using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Entity representing a customer order.
    /// Contains information about the order, its status, and related items.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier of the order.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Unique identifier of the user who placed the order.
        /// </summary>
        public required Guid UserId { get; set; }

        /// <summary>
        /// Navigation property to the user who placed the order.
        /// Optional for lazy loading scenarios.
        /// </summary>
        public ApplicationUser? User { get; set; }

        
        /// Date and time when the order was placed.
        
        public required DateTime OrderDate { get; set; }

        
        /// Current status of the order.
        
        public required StatusType Status { get; set; }

        
        /// Shipping address for the order.
        
        public required string ShippingAddress { get; set; }

        
        /// Collection of items included in the order.
        
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }
}
