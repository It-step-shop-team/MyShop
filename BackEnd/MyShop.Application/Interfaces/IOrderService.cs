using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<PublicOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<PublicOrderDto?> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<PublicOrderDto>> GetOrdersByUserIdAsync(Guid userId);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, string status);
        Task<bool> CancelOrderAsync(Guid orderId);
        Task<IEnumerable<PublicOrderDto>> GetAllOrdersAsync();
    }
}
