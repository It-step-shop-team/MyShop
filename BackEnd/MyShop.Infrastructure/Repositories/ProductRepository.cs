using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Product"/> entities.
    /// Provides methods for retrieving, adding, updating, and deleting products.
    /// </summary>
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        /// <summary>
        /// Retrieves a product by its unique identifier, including its category and associated tags.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The <see cref="Product"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                    .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Retrieves all products, including their categories and associated tags.
        /// </summary>
        /// <returns>A list of all <see cref="Product"/> entities.</returns>
        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<ICollection<Product>> GetByCategoryAsync(Guid category) =>
            await context.Products
                .Where(p => p.CategoryId == category)
                .ToListAsync();
        
        public async Task<ICollection<Product>> GetByTagsAsync(IEnumerable<Guid> tagIds)
        {
            var tagIdList = tagIds.ToList();

            return await context.Products
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p => p.ProductTags
                    .Count(pt => tagIdList.Contains(pt.TagId)) == tagIdList.Count)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to add.</param>
        public async Task<Product?> AddAsync(Product product) =>
            (await context.Products.AddAsync(product)).Entity;


        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> with updated data.</param>
        public async Task<Product?> UpdateAsync(Product product)
        {
            Product? productToUpdate = await context.Products.FindAsync(product.Id);

            if (productToUpdate is null)
                return null;
            
            productToUpdate.Name = product.Name;
            
            productToUpdate.Description =  product.Description;
            
            productToUpdate.CategoryId = product.CategoryId;
                
            productToUpdate.Category = null;
            
            productToUpdate.ProductTags.Clear();
            
            foreach (var tag in product.ProductTags)
                productToUpdate.ProductTags.Add(tag);
            
            productToUpdate.ImageUrl = product.ImageUrl;
            
            productToUpdate.Price = product.Price;
            
            return productToUpdate;
        }

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        public async Task<Product?> DeleteAsync(Guid id)
        {
            Product? productToDelete = await context.Products.FindAsync(id);
            
            if (productToDelete != null)
                context.Products.Remove(productToDelete);

            return productToDelete;
        }

        public async Task<ICollection<Product>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Product>();

            searchTerm = searchTerm.ToLower();

            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm)) ||
                    (p.Category != null && p.Category.Name.ToLower().Contains(searchTerm)) ||
                    p.ProductTags.Any(pt => pt.Tag != null && pt.Tag.Name.ToLower().Contains(searchTerm))
                )
                .ToListAsync();
        }
    }
}
