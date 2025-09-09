using MyShop.Domain.Entities;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Repository interface for managing <see cref="Order"/> entities.
    /// Defines methods for retrieving, adding, updating, and deleting orders.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The <see cref="Order"/> if found; otherwise, <c>null</c>.</returns>
        Task<Order?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A collection of all <see cref="Order"/> entities.</returns>
        Task<ICollection<Order>> GetAllAsync();
        Task<ICollection<Order>> GetByUserIdAsync(Guid orderId);
        /// <summary>
        /// Adds a new order.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> to add.</param>
        Task<Order?> AddAsync(Order order);

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> with updated data.</param>
        Task<Order?> UpdateAsync(Order order);

        Task<Order?> UpdateStatusAsync(Guid orderId, StatusType status);

        /// <summary>
        /// Deletes an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to delete.</param>
        Task<Order?> DeleteAsync(Guid id);
    }
}
