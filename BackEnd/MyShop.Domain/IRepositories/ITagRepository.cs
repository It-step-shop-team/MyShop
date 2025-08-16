using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.IRepositories
{
    public interface ITagRepository
    {
        Task<Tag?> AddAsync(Tag tag);
        Task<IEnumerable<Tag>?> GetAllAsync();
    }
}
