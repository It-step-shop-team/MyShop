using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Common.Errors;
using MyShop.Domain.IRepositories;
using ErrorOr;
using MyShop.Application.Mappers;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<ErrorOr<PublicOrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (!createOrderDto.OrderItems.Any())
                return ErrorTypes.Validation.InvalidOrderData;

            var order = OrderMapper.ToDatabaseObject(createOrderDto);

            var result = await orderRepository.AddAsync(order);
            
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

        public async Task<ErrorOr<ICollection<PublicOrderDto>>> GetOrdersByUserIdAsync(Guid userId)
        {
            var result = await orderRepository.GetByUserIdAsync(userId);
            
            if (!result.Any())
                return ErrorTypes.NotFound.OrdersNotFound;
            
            return OrderMapper.ToDtoList(result);
        }

        public async Task<ErrorOr<PublicOrderDto>> UpdateOrderStatusAsync(Guid orderId, StatusType status)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order is null)
                return ErrorTypes.NotFound.OrderNotFound;

            var result = await orderRepository.UpdateStatusAsync(orderId, status);
            if (result is null)
                return ErrorTypes.Conflict.UpdateOrder;
            
            await unitOfWork.SaveChangesAsync();
            return OrderMapper.ToDto(result);
        }

        public async Task<ErrorOr<PublicOrderDto>> CancelOrderAsync(Guid orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order is null)
                return ErrorTypes.NotFound.OrderNotFound;

            var result = await orderRepository.UpdateStatusAsync(orderId, StatusType.Cancelled);
            if (result is null) 
                return ErrorTypes.Conflict.UpdateOrder;
                
            await unitOfWork.SaveChangesAsync();

            return OrderMapper.ToDto(result);
        }

        public async Task<ErrorOr<ICollection<PublicOrderDto>>> GetAllOrdersAsync()
        {
            var result = await orderRepository.GetAllAsync();
            if (!result.Any())
                return ErrorTypes.NotFound.OrdersNotFound;

            return OrderMapper.ToDtoList(result);
        }
    }
}
