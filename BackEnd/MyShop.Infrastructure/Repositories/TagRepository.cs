using Microsoft.EntityFrameworkCore;
using MyShop.Domain.IRepositories;
using MyShop.Domain.ListLikeEntities;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Tag"/> entities.
    /// Provides methods for retrieving, adding, updating, and deleting tags.
    /// </summary>
    public class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        /// <summary>
        /// Retrieves a tag by its unique identifier, including its associated products and their categories.
        /// </summary>
        /// <param name="id">The unique identifier of the tag.</param>
        /// <returns>The <see cref="Tag"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<Tag?> GetByIdAsync(Guid id) =>
            await context.Tags
                          .Include(t => t.ProductTags)
                          .ThenInclude(pt => pt.Product)
                          .FirstOrDefaultAsync(t => t.Id == id);

        /// <summary>
        /// Retrieves all tags, including their associated products.
        /// </summary>
        /// <returns>A collection of all <see cref="Tag"/> entities.</returns>
        public async Task<ICollection<Tag>> GetAllAsync() =>
            await context.Tags
                          .Include(t => t.ProductTags)
                          .ToListAsync();

        /// <summary>
        /// Adds a new tag to the database.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to add.</param>
        public async Task<Tag?> AddAsync(Tag tag) =>
            (await context.Tags.AddAsync(tag)).Entity;

        /// <summary>
        /// Updates an existing tag in the database.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> with updated data.</param>
        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            Tag? tagToUpdate = await context.Tags.FindAsync(tag.Id);

            if (tagToUpdate is null)
                return null;
            
            return tagToUpdate;
        }

        /// <summary>
        /// Deletes a tag by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tag to delete.</param>
        public async Task<Tag?> DeleteAsync(Guid id)
        {
            Tag? tagToDetete = await context.Tags.FindAsync(id);
                
            if (tagToDetete is null)
                return null;
            
            context.Tags.Remove(tagToDetete);
            
            return tagToDetete;
        }
    }
}
