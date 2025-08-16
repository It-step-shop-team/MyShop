using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Common.Errors;
using MyShop.Domain.IRepositories;
using ErrorOr;
using MyShop.Application.Mappers;

namespace MyShop.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<ErrorOr<PublicOrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (!createOrderDto.OrderItems.Any())
                return ErrorTypes.Validation.InvalidOrderData;

            var order = OrderMapper.ToDatabaseObject(createOrderDto);

            var result = await orderRepository.CreateAsync(order);
            
            if (result is null)
                return ErrorTypes.Conflict.DuplicateOrderId;
            
            await unitOfWork.SaveChangesAsync();

            return OrderMapper.ToDto(result);
        }

        public async Task<ErrorOr<PublicOrderDto>> GetOrderByIdAsync(Guid orderId)
        {
            var result = await orderRepository.GetByIdAsync(orderId);
            if (result is null)
                return ErrorTypes.NotFound.OrderNotFound;

            return OrderMapper.ToDto(result);
        }

        public async Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetOrdersByUserIdAsync(Guid userId)
        {
            var result = await orderRepository.GetByUserIdAsync(userId);
            
            if (result is null)
                return ErrorTypes.NotFound.OrdersNotFound;
            
            return OrderMapper.ToDtoList(result);
        }

        public async Task<ErrorOr<bool>> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order is null)
                return ErrorTypes.NotFound.OrderNotFound;

            var result = await orderRepository.UpdateStatusAsync(orderId, status);
            if (result == false)
                return ErrorTypes.Conflict.UpdateOrder;
            
            await unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<ErrorOr<bool>> CancelOrderAsync(Guid orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order is null)
                return ErrorTypes.NotFound.OrderNotFound;

            var result = await orderRepository.CancelAsync(orderId);
            if (result == false) 
                return ErrorTypes.Conflict.UpdateOrder;
                
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            if (orders is null)
                return ErrorTypes.NotFound.OrdersNotFound;

            return OrderMapper.ToDtoList(orders);
        }
    }
}
