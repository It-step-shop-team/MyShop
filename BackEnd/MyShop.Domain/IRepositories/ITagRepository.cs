using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.IRepositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagType>> GetAllTagsAsync();
    }
}
