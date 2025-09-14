using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.IRepositories;

public interface IRoleRepository
{
    Task<ICollection<Role>> GetAllAsync();
    Task<Role?> AddAsync (Role role);
    Task<Role?> DeleteAsync (Role role);
}