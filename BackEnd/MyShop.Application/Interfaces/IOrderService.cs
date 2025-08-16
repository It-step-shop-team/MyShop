using MyShop.Application.DTOs;
using ErrorOr;

namespace MyShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<ErrorOr<PublicOrderDto>> GetOrderByIdAsync(Guid orderId);
        Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetAllOrdersAsync();
        Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetOrdersByUserIdAsync(Guid userId);
        Task <ErrorOr<PublicOrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<ErrorOr<bool>> UpdateOrderStatusAsync(Guid orderId, string status);
        Task<ErrorOr<bool>> CancelOrderAsync(Guid orderId);
    }
}
