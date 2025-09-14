using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class RefreshRepository(ApplicationDbContext context) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == token, cancellationToken);
    }

    public async Task<ICollection<RefreshToken>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<RefreshToken?> AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default) =>
        (await context.RefreshTokens.AddAsync(refreshToken, cancellationToken)).Entity;

    public async Task<RefreshToken?> UpdateAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        // Проверяем, есть ли токен в базе
        var existingToken = await context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Id == refreshToken.Id, cancellationToken);

        if (existingToken == null)
            return null;
        
        // Обновляем поля
        existingToken.Token = refreshToken.Token;
        existingToken.ExpiresAt = refreshToken.ExpiresAt;
        existingToken.IsRevoked = refreshToken.IsRevoked;

        return existingToken;
    }

    public async Task<RefreshToken?> DeleteAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        // Проверяем, есть ли токен в базе
        var existingToken = await context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Id == refreshToken.Id, cancellationToken);

        if (existingToken == null)
            return null;

        context.RefreshTokens.Remove(existingToken);
        
        return existingToken;
    }
}