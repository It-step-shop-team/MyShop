using MyShop.Domain.BaseEntities;
using MyShop.Domain.IRepositories;
using MyShop.infrastructure.Data;

namespace MyShop.infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext _context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await Task.FromResult(Enum.GetValues<Category>());
        }
    }
}
