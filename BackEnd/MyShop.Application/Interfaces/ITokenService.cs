
using ErrorOr;
using MyShop.Application.DTOs.UserDTOs;

namespace MyShop.Application.Interfaces;

public interface ITokenService
{
    Task<ErrorOr<AuthResponseDto>> GenerateTokensAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<ErrorOr<AuthResponseDto>> RefreshTokensAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<ErrorOr<string>> RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
}