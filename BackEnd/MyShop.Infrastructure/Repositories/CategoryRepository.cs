using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.Repositories;
using MyShop.Infrastructure.Persistence;

namespace MyShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Category"/> entities.
    /// Provides methods for retrieving, adding, updating, and deleting categories.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="CategoryRepository"/> with the specified database context.
        /// </summary>
        /// <param name="context">The database context to use.</param>
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a category by its unique identifier, including related products.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The <see cref="Category"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<Category?> GetByIdAsync(Guid id) =>
            await _context.Categories
                          .Include(c => c.Products)
                          .FirstOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Retrieves all categories, including related products.
        /// </summary>
        /// <returns>A collection of all <see cref="Category"/> entities.</returns>
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _context.Categories
                          .Include(c => c.Products)
                          .ToListAsync();

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to add.</param>
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> with updated data.</param>
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
