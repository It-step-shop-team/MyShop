using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Persistence;

namespace MyShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Tag"/> entities.
    /// Provides methods for retrieving, adding, updating, and deleting tags.
    /// </summary>
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="TagRepository"/> with the specified database context.
        /// </summary>
        /// <param name="context">The database context to use.</param>
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a tag by its unique identifier, including its associated products and their categories.
        /// </summary>
        /// <param name="id">The unique identifier of the tag.</param>
        /// <returns>The <see cref="Tag"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<Tag?> GetByIdAsync(Guid id) =>
            await _context.Tags
                          .Include(t => t.Products)
                          .ThenInclude(p => p.Category)
                          .FirstOrDefaultAsync(t => t.Id == id);

        /// <summary>
        /// Retrieves all tags, including their associated products.
        /// </summary>
        /// <returns>A collection of all <see cref="Tag"/> entities.</returns>
        public async Task<IEnumerable<Tag>> GetAllAsync() =>
            await _context.Tags
                          .Include(t => t.Products)
                          .ToListAsync();

        /// <summary>
        /// Adds a new tag to the database.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to add.</param>
        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing tag in the database.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> with updated data.</param>
        public async Task UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a tag by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tag to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}
