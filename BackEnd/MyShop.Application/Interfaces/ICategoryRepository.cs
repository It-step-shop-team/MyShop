using MyShop.Domain.Entities;

namespace MyShop.Application.Repositories
{
    /// <summary>
    /// Defines a contract for accessing and managing <see cref="Category"/> entities in the data store.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the <see cref="Category"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<Category?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all categories from the data store.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a collection of <see cref="Category"/> entities.
        /// </returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Adds a new category to the data store.
        /// </summary>
        /// <param name="category">The category entity to add.</param>
        Task AddAsync(Category category);

        /// <summary>
        /// Updates an existing category in the data store.
        /// </summary>
        /// <param name="category">The category entity to update.</param>
        Task UpdateAsync(Category category);

        /// <summary>
        /// Deletes an existing category from the data store.
        /// </summary>
        /// <param name="category">The category entity to delete.</param>
        Task DeleteAsync(Category category);
    }
}
