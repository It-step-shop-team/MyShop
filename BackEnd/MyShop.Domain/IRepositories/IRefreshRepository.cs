using MyShop.Domain.Entities;

namespace MyShop.Domain.IRepositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);
    Task<ICollection<RefreshToken>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<RefreshToken?> AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
    Task<RefreshToken?> UpdateAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
    Task<RefreshToken?> DeleteAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
}