using ErrorOr;
using MyShop.Application.DTOs;
using MyShop.Domain.Entities;

namespace MyShop.Application.Mappers
{
    public static class OrderMapperWithErrorOr
    {
        
        public static ErrorOr<Order> ToDatabaseObject(CreateOrderDto dto)
        {
            if (dto == null)
                return Error.Validation("Order.InvalidData", "Invalid order data provided.");

            if (dto.UserId == Guid.Empty)
                return Error.Validation("Order.InvalidUserId", "User ID is required.");

            if (string.IsNullOrWhiteSpace(dto.ShippingAddress))
                return Error.Validation("Order.InvalidShippingAddress", "Shipping address is required.");

            if (dto.TotalAmount <= 0)
                return Error.Validation("Order.InvalidTotalAmount", "Total amount must be greater than zero.");

            var orderId = Guid.NewGuid();
            
            var order = new Order
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

            return order;
        }

                public static ErrorOr<PublicOrderDto> ToDto(Order databaseObject)
        {
            if (databaseObject == null)
                return Error.NotFound("Order.NotFound", "Order not found.");

            var dto = new PublicOrderDto
            {
                Id = databaseObject.Id,
                UserId = databaseObject.UserId,
                OrderDate = databaseObject.OrderDate,
                Status = databaseObject.Status,
                ShippingAddress = databaseObject.ShippingAddress
            };

            return dto;
        }

       
       
public static ErrorOr<List<PublicOrderDto>> ToDtoList(IEnumerable<Order> databaseObjects)
{
    if (databaseObjects == null)
        return Error.NotFound("Order.ListNotFound", "Order list not found.");

    var dtos = new List<PublicOrderDto>();

    foreach (var order in databaseObjects)
    {
        var result = ToDto(order);
        if (result.IsError)
        {
            return result.Errors; 
        }
        dtos.Add(result.Value);
    }

    return dtos;
}
    }
}
