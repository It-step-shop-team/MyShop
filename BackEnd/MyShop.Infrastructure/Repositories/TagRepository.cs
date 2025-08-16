using MyShop.Domain.BaseEntities;
using MyShop.Domain.IRepositories;
using MyShop.infrastructure.Data;

namespace MyShop.infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await Task.FromResult(Enum.GetValues<Tag>());
        }
    }
}
