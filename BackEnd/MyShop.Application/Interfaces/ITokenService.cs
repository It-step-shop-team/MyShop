
using ErrorOr;

namespace MyShop.Application.Interfaces;

public interface ITokenService
{
    Task<ErrorOr<(string AccessToken, string RefreshToken)>> GenerateTokensAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<ErrorOr<(string AccessToken, string RefreshToken)>> RefreshTokensAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<ErrorOr<string>> RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
}