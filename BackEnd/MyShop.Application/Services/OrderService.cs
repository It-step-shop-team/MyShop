using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Common.Errors;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using ErrorOr;

namespace MyShop.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<ErrorOr<PublicOrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            try
            {
                if (createOrderDto == null)
                    return ErrorTypes.Validation.InvalidOrderData;

                if (createOrderDto.OrderItems == null || !createOrderDto.OrderItems.Any())
                    return ErrorTypes.Validation.InvalidOrderData;

                var orderId = Guid.NewGuid();
                
                var order = new Order
                {
                    Id = orderId,
                    UserId = createOrderDto.UserId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending",
                    ShippingAddress = createOrderDto.ShippingAddress,
                    OrderItems = createOrderDto.OrderItems.Select(item => new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    }).ToList(),
                };

                var result = await orderRepository.CreateAsync(order);
                await unitOfWork.SaveChangesAsync();

                return new PublicOrderDto
                {
                    Id = orderId,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    ShippingAddress = order.ShippingAddress
                };
            }
            catch (Exception)
            {
                return ErrorTypes.Validation.InvalidOrderData;
            }
        }

        public async Task<ErrorOr<PublicOrderDto?>> GetOrderByIdAsync(Guid orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ErrorTypes.NotFound.OrderNotFound;
            }

            return new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            };
        }

        public async Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetByUserIdAsync(userId);
            return orders.Select(order => new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            }).ToList();
        }

        public async Task<ErrorOr<bool>> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ErrorTypes.NotFound.OrderNotFound;
            }

            var result = await orderRepository.UpdateStatusAsync(orderId, status);
            if (result)
            {
                await unitOfWork.SaveChangesAsync();
            }

            return result;
        }

        public async Task<ErrorOr<bool>> CancelOrderAsync(Guid orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ErrorTypes.NotFound.OrderNotFound;
            }

            var result = await orderRepository.CancelAsync(orderId);
            if (result)
            {
                await unitOfWork.SaveChangesAsync();
            }

            return result;
        }

        public async Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            return orders.Select(order => new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            }).ToList();
        }
    }
}
