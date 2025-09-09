using MyShop.Domain.Entities;

namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Repository interface for managing <see cref="Product"/> entities.
    /// Defines methods for retrieving, adding, updating, deleting, and searching products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The <see cref="Product"/> if found; otherwise, <c>null</c>.</returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all <see cref="Product"/> entities; or <c>null</c> if none found.</returns>
        Task<ICollection<Product>> GetAllAsync();

        /// <summary>
        /// Retrieves products that belong to a specific category.
        /// </summary>
        /// <param name="category">The category to filter products by.</param>
        /// <returns>A collection of products within the specified category; or <c>null</c> if none found.</returns>
        Task<ICollection<Product>> GetByCategoryAsync(Guid category);

        /// <summary>
        /// Retrieves products associated with the specified tags.
        /// </summary>
        /// <returns>A collection of products matching the specified tags; or <c>null</c> if none found.</returns>
        Task<ICollection<Product>> GetByTagsAsync(IEnumerable<Guid> tagsId);

        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to add.</param>
        /// <returns>The added <see cref="Product"/>; or <c>null</c> if addition failed.</returns>
        Task<Product?> AddAsync(Product product);

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> with updated data.</param>
        /// <returns>The updated <see cref="Product"/>; or <c>null</c> if update failed.</returns>
        Task<Product?> UpdateAsync(Product product);

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns><c>true</c> if deletion was successful; otherwise, <c>false</c>.</returns>
        Task<Product?> DeleteAsync(Guid id);

        /// <summary>
        /// Searches for products whose titles match the given search term.
        /// </summary>
        /// <param name="searchTerm">The term to search for in product titles.</param>
        /// <returns>A collection of matching products; or <c>null</c> if none found.</returns>
        Task<ICollection<Product>> SearchAsync(string searchTerm);
    }
}
