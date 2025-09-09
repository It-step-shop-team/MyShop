using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Repository interface for managing <see cref="Tag"/> entities.
    /// Defines methods for retrieving, adding, updating, and deleting tags.
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Retrieves a tag by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tag.</param>
        /// <returns>The <see cref="Tag"/> if found; otherwise, <c>null</c>.</returns>
        Task<Tag?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>A collection of all <see cref="Tag"/> entities.</returns>
        Task<ICollection<Tag>> GetAllAsync();

        /// <summary>
        /// Adds a new tag to the repository.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to add.</param>
        Task<Tag?> AddAsync(Tag tag);

        /// <summary>
        /// Updates an existing tag in the repository.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> with updated data.</param>
        Task<Tag?> UpdateAsync(Tag tag);

        /// <summary>
        /// Deletes a tag by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tag to delete.</param>
        Task<Tag?> DeleteAsync(Guid id);
    }
}
