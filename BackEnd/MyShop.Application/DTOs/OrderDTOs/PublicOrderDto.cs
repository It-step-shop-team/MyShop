using MyShop.Domain.ListLikeEntities;

namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for returning order information
    /// that can be exposed publicly (e.g., in API responses).
    /// </summary>
    public class PublicOrderDto
    {
        /// <summary>
        /// The unique identifier of the order.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// The unique identifier of the user who placed the order.
        /// </summary>
        public required Guid UserId { get; init; }

        /// <summary>
        /// The date and time when the order was created.
        /// </summary>
        public required DateTime OrderDate { get; init; }

        /// <summary>
        /// The current status of the order.
        /// Based on <see cref="StatusType"/> enumeration.
        /// </summary>
        public required StatusType Status { get; init; }

        /// <summary>
        /// The shipping address where the order should be delivered.
        /// </summary>
        public required string ShippingAddress { get; init; }
    }
}
