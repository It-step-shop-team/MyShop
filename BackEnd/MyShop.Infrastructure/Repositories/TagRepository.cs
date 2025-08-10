using MyShop.Domain.BaseEntities;
using MyShop.Domain.IRepositories;
using Myshop.infrastructure.Data;

namespace Myshop.infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagType>> GetAllTagsAsync()
        {
            return await Task.FromResult(Enum.GetValues<TagType>());
        }
    }
}
