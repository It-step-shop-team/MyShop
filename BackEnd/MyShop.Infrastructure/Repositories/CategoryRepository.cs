using Microsoft.EntityFrameworkCore;
using MyShop.Domain.IRepositories;
using MyShop.Domain.ListLikeEntities;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Category"/> entities.
    /// Provides methods for retrieving, adding, updating, and deleting categories.
    /// </summary>
    public class CategoryRepository (ApplicationDbContext context) : ICategoryRepository
    {
        /// <summary>
        /// Retrieves a category by its unique identifier, including related products.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The <see cref="Category"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<Category?> GetByIdAsync(Guid id) =>
            await context.Categories
                          .Include(c => c.Products)
                          .FirstOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Retrieves all categories, including related products.
        /// </summary>
        /// <returns>A collection of all <see cref="Category"/> entities.</returns>
        public async Task<ICollection<Category>> GetAllAsync() =>
            await context.Categories
                          .ToListAsync();

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to add.</param>
        public async Task<Category?> AddAsync(Category category) =>
            (await context.Categories.AddAsync(category)).Entity;

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> with updated data.</param>
        public async Task<Category?> UpdateAsync(Category category)
        {
            Category? categoryToUpdate = await context.Categories.FindAsync(category.Id);
            
            if (categoryToUpdate is null)
                return null;
            
            categoryToUpdate.Name = category.Name;
            
            return categoryToUpdate;
        }

        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        public async Task<Category?> DeleteAsync(Guid id)
        {
            var categoryToDelete = await context.Categories.FindAsync(id);
            if (categoryToDelete is null)
                return null;
            
            context.Categories.Remove(categoryToDelete);
            return categoryToDelete;
        }
    }
}
