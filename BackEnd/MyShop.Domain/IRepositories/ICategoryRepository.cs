using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryType>> GetAllCategoriesAsync();
    }
}
