using MyShop.Application.DTOs;
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
                Status = "Pending",
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
        /// <param name="databaseObject">The Order entity from database</param>
        /// <returns>PublicOrderDto for client response</returns>
        public static PublicOrderDto ToDto(Order databaseObject)
        {
            return new PublicOrderDto
            {
                Id = databaseObject.Id,
                UserId = databaseObject.UserId,
                OrderDate = databaseObject.OrderDate,
                Status = databaseObject.Status,
                ShippingAddress = databaseObject.ShippingAddress
            };
        }

        /// <summary>
        /// Converts a list of Order entities to a list of PublicOrderDto
        /// </summary>
        /// <param name="databaseObjects">List of Order entities</param>
        /// <returns>List of PublicOrderDto</returns>
        public static List<PublicOrderDto> ToDtoList(IEnumerable<Order> databaseObjects)
        {
            return databaseObjects.Select(ToDto).ToList();
        }
    }
}
