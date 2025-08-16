using MyShop.Application.DTOs;
using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Application.Mappers
{
    public static class OrderMapper
    {
        /// <summary>
        /// Converts a CreateOrderDto to an Order entity for database storage
        /// </summary>
        /// <param name="dto">The CreateOrderDto to convert</param>
        /// <returns>Order entity ready for database storage</returns>
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
                OrderItems = dto.OrderItems?.Select(item => new OrderItem
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
        /// Converts an Order entity to a PublicOrderDto for client response
        /// </summary>
        /// <param name="order">The Order entity from database</param>
        /// <returns>PublicOrderDto for client response</returns>
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
        /// Converts a list of Order entities to a list of PublicOrderDto
        /// </summary>
        /// <param name="orders">List of Order entities</param>
        /// <returns>List of PublicOrderDto</returns>
        public static List<PublicOrderDto> ToDtoList(IEnumerable<Order> orders)
        {
            return orders.Select(ToDto).ToList();
        }
    }
}
