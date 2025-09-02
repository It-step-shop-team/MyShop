using MyShop.Application.DTOs;
using ErrorOr;

namespace MyShop.Application.Interfaces
{
    /// <summary>
    /// Defines business logic operations related to orders,
    /// such as creation, retrieval, updating, and cancellation.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Retrieves a single order by its unique identifier.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing the <see cref="PublicOrderDto"/> 
        /// if the order exists, or an error if not found.
        /// </returns>
        Task<ErrorOr<PublicOrderDto>> GetOrderByIdAsync(Guid orderId);

        /// <summary>
        /// Retrieves all orders in the system.
        /// </summary>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing a collection of <see cref="PublicOrderDto"/> 
        /// or an error if no orders are found.
        /// </returns>
        Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetAllOrdersAsync();

        /// <summary>
        /// Retrieves all orders associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing a collection of <see cref="PublicOrderDto"/> 
        /// or an error if no orders are found for the user.
        /// </returns>
        Task<ErrorOr<IEnumerable<PublicOrderDto>>> GetOrdersByUserIdAsync(Guid userId);

        /// <summary>
        /// Creates a new order based on the provided data.
        /// </summary>
        /// <param name="createOrderDto">The DTO containing order details.</param>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing the created <see cref="PublicOrderDto"/> 
        /// or an error if creation fails.
        /// </returns>
        Task<ErrorOr<PublicOrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto);

        /// <summary>
        /// Updates the status of an existing order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <param name="status">The new status value for the order.</param>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing <c>true</c> if the update succeeds, 
        /// or an error if the operation fails.
        /// </returns>
        Task<ErrorOr<bool>> UpdateOrderStatusAsync(Guid orderId, string status);

        /// <summary>
        /// Cancels an existing order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to cancel.</param>
        /// <returns>
        /// An <see cref="ErrorOr{TValue}"/> containing <c>true</c> if the cancellation succeeds, 
        /// or an error if the operation fails.
        /// </returns>
        Task<ErrorOr<bool>> CancelOrderAsync(Guid orderId);
    }
}
