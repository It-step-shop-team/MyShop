using MyShop.Application.DTOs.OrderDTOs;
using MyShop.Domain.Entities;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Application.Mappers
{
    /// <summary>
    /// Static class for mapping orders.
    /// Provides methods for converting between DTOs and Order entities.
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// Converts a <see cref="CreateOrderDto"/> into an <see cref="Order"/> entity for database storage.
        /// </summary>
        /// <param name="dto">The DTO containing data to create the order.</param>
        /// <returns>An <see cref="Order"/> entity ready to be stored in the database.</returns>
        public static Order ToDatabaseObject(CreateOrderDto dto)
        {
            var orderId = Guid.NewGuid();

            return new Order
            {
                Id = orderId,
                UserId = dto.UserId,
                OrderDate = DateTime.UtcNow,
                Status = StatusType.Created,
                ShippingAddress = dto.ShippingAddress,
                OrderItems = dto.OrderItems.Select(item => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };
        }

        /// <summary>
        /// Converts an <see cref="Order"/> entity into a <see cref="PublicOrderDto"/> for client response.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> entity from the database.</param>
        /// <returns>A <see cref="PublicOrderDto"/> for sending to the client.</returns>
        public static PublicOrderDto ToDto(Order order)
        {
            return new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            };
        }

        /// <summary>
        /// Converts a list of <see cref="Order"/> entities into a list of <see cref="PublicOrderDto"/>.
        /// </summary>
        /// <param name="orders">The list of <see cref="Order"/> entities.</param>
        /// <returns>A list of <see cref="PublicOrderDto"/> for sending to the client.</returns>
        public static List<PublicOrderDto> ToDtoList(IEnumerable<Order> orders)
        {
            return orders.Select(ToDto).ToList();
        }
    }
}
