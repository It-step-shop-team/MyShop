using MyShop.Domain.Entities;
using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.IRepositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>?> GetAllAsync();
        Task<IEnumerable<Product>?> GetByCategoryAsync(Category category);
        Task<IEnumerable<Product>?> GetByTagsAsync(IEnumerable<Tag> tags);
        Task<Product?> AddAsync(Product product);
        Task<Product?> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<Product>?> SearchAsync(string searchTerm);
    }
}

