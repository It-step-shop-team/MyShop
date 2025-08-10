using MyShop.Domain.Entities;

namespace MyShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(Guid id);
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<ApplicationUser?> GetByLoginAsync(string login);
        Task<IEnumerable<ApplicationUser>?> GetAllAsync();
        Task<ApplicationUser?> AddAsync(ApplicationUser user);
        Task<ApplicationUser?> UpdateAsync(ApplicationUser user);
        Task<bool> DeleteAsync(Guid id);
    }
}
