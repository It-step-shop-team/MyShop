using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;

namespace MyShop.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<PublicOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var orderId = Guid.NewGuid();
            
            var order = new Order
            {
                Id = orderId,
                UserId = createOrderDto.UserId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                ShippingAddress = createOrderDto.ShippingAddress,
                OrderItems = createOrderDto.OrderItems?.Select(item => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }),
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

        public async Task<PublicOrderDto?> GetOrderByIdAsync(Guid orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null) return null;

            return new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            };
        }

        public async Task<IEnumerable<PublicOrderDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetByUserIdAsync(userId);
            return orders.Select(order => new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            });
        }

        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var result = await orderRepository.UpdateStatusAsync(orderId, status);
            await unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> CancelOrderAsync(Guid orderId)
        {
            var result = await orderRepository.CancelAsync(orderId);
            await unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<PublicOrderDto>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            return orders.Select(order => new PublicOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            });
        }
    }
}
