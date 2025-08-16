using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category?> AddAsync(Category category);
        Task<IEnumerable<Category>?> GetAllAsync();
    }
}
