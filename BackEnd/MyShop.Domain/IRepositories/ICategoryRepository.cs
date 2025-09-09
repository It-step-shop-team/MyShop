using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Repository interface for managing <see cref="Category"/> entities.
    /// Defines methods for retrieving, adding, updating, and deleting categories.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The <see cref="Category"/> if found; otherwise, <c>null</c>.</returns>
        Task<Category?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A collection of all <see cref="Category"/> entities.</returns>
        Task<ICollection<Category>> GetAllAsync();

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to add.</param>
        Task<Category?> AddAsync(Category category);

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> with updated data.</param>
        Task<Category?> UpdateAsync(Category category);

        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        Task<Category?> DeleteAsync(Guid id);
    }
}
