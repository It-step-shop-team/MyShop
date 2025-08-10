using MyShop.Domain.Entities;

namespace MyShop.Domain.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order?> CreateAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>?> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Order>?> GetAllAsync();
        Task<bool> UpdateStatusAsync(Guid orderId, string status);
        Task<bool> CancelAsync(Guid orderId);
    }
}
