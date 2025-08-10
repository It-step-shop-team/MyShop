using MyShop.Domain.IRepositories;
using Myshop.infrastructure.Data;

namespace Myshop.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderRepository _orders;
        private readonly IProductRepository _products;
        private readonly IUserRepository _users;
        private readonly ICategoryRepository _categories;
        private readonly ITagRepository _tags;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _orders = new OrderRepository(context);
            _products = new ProductRepository(context);
            _users = new UserRepository(context);
            _categories = new CategoryRepository(context);
            _tags = new TagRepository(context);
        }

        public IOrderRepository Orders => _orders;
        public IProductRepository Products => _products;
        public IUserRepository Users => _users;
        public ICategoryRepository Categories => _categories;
        public ITagRepository Tags => _tags;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
