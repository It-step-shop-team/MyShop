using MyShop.Domain.Entities;

namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Repository interface for managing <see cref="ApplicationUser"/> entities.
    /// Defines methods for retrieving, adding, updating, and deleting users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The <see cref="ApplicationUser"/> if found; otherwise, <c>null</c>.</returns>
        Task<ApplicationUser?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The <see cref="ApplicationUser"/> if found; otherwise, <c>null</c>.</returns>
        Task<ApplicationUser?> GetByEmailAsync(string email);

        /// <summary>
        /// Retrieves a user by their login name.
        /// </summary>
        /// <param name="login">The login of the user.</param>
        /// <returns>The <see cref="ApplicationUser"/> if found; otherwise, <c>null</c>.</returns>
        Task<ApplicationUser?> GetByLoginAsync(string login);

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A collection of all <see cref="ApplicationUser"/> entities; or <c>null</c> if none found.</returns>
        Task<IEnumerable<ApplicationUser>?> GetAllAsync();

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The <see cref="ApplicationUser"/> to add.</param>
        /// <returns>The added <see cref="ApplicationUser"/>; or <c>null</c> if addition failed.</returns>
        Task<ApplicationUser?> AddAsync(ApplicationUser user);

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="user">The <see cref="ApplicationUser"/> with updated data.</param>
        /// <returns>The updated <see cref="ApplicationUser"/>; or <c>null</c> if update failed.</returns>
        Task<ApplicationUser?> UpdateAsync(ApplicationUser user);

        /// <summary>
        /// Deletes a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns><c>true</c> if deletion was successful; otherwise, <c>false</c>.</returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
