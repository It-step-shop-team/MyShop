using Microsoft.EntityFrameworkCore;
using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using Myshop.infrastructure.Data;

namespace Myshop.infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Products.FindAsync(id);
        }
        
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>?> GetByCategoryAsync(CategoryType category)
        {
            return await context.Products.Where(p => p.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<Product>?> GetByTagsAsync(IEnumerable<TagType> tags)
        {
            return await context.Products
                .Where(p => p.Tags.Any(tag => tags.Contains(tag)))
                .ToListAsync();
        }

        public async Task<Product?> AddAsync(Product product)
        {
            var entry = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                return null;
            }

            context.Entry(existingProduct).CurrentValues.SetValues(product);
            await context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<Product>?> SearchAsync(string searchTerm)
        {
            return await context.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
