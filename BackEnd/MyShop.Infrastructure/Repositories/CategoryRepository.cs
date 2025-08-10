using MyShop.Domain.BaseEntities;
using MyShop.Domain.IRepositories;
using Myshop.infrastructure.Data;

namespace Myshop.infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryType>> GetAllCategoriesAsync()
        {
            return await Task.FromResult(Enum.GetValues<CategoryType>());
        }
    }
}
