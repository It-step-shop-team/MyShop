using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ErrorOr;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.DTOs.UserDTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;

namespace MyShop.Infrastructure.Services;

public class TokenService(IConfiguration config, IUnitOfWork unitOfWork , IUserRepository userRepository, IRefreshTokenRepository tokenRepository) : ITokenService
{
    private double AccessTokenLifetimeMinutes => Convert.ToDouble(config["Jwt:AccessTokenLifetimeMinutes"]);
    
    private double RefreshTokenLifetimeDays => Convert.ToDouble(config["Jwt:RefreshTokenLifetimeDays"]);
    private string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var jwtSettings = config.GetSection("Jwt");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(AccessTokenLifetimeMinutes),
            signingCredentials: credentials
            );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string GenerateRefreshToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
    public async Task<ErrorOr<AuthResponseDto>> GenerateTokensAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId);

        if (user is null)
            return Error.NotFound(code: "JwtToken.User", description: "User not found");
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.RoleId.ToString())
        };
        
        var accessToken = GenerateAccessToken(claims);
        var refreshToken = GenerateRefreshToken();
        
        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(RefreshTokenLifetimeDays),
            IsRevoked = false
        };

        try
        {
            await tokenRepository.AddAsync(refreshTokenEntity, cancellationToken);
        }
        catch (Exception ex)
        {
            return Error.Failure("Database", "Failed to save refresh token: " + ex.Message);
        }

        await unitOfWork.SaveChangesAsync();
        
        AuthResponseDto authResponseDto = new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            FullName = $"{user.FirstName} {user.LastName}"
        };
        
        return authResponseDto;
    }
    public async Task<ErrorOr<AuthResponseDto>> RefreshTokensAsync(string oldRefreshToken, CancellationToken cancellationToken = default)
    { 
        var oldRefreshTokenEntity = await tokenRepository.GetByTokenAsync(oldRefreshToken, cancellationToken);
        
        if (oldRefreshTokenEntity is null)
            return Error.Conflict(code:"RefreshToken", description: "RefreshToken not found");
        
        if (oldRefreshTokenEntity.ExpiresAt < DateTime.UtcNow)
            return Error.Conflict(code:"RefreshToken", description: "Refresh token expired");
        
        await tokenRepository.DeleteAsync(oldRefreshTokenEntity, cancellationToken);
        
        var user = await userRepository.GetByIdAsync(oldRefreshTokenEntity.UserId);
        
        if (user is null)
            return Error.NotFound(code: "RefreshToken.User", description: "User not found");
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.RoleId.ToString())
        };
        
        var newAccessToken = GenerateAccessToken(claims);
        var newRefreshToken = GenerateRefreshToken();
        
        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(RefreshTokenLifetimeDays),
            IsRevoked = false
        };

        try
        {
            await tokenRepository.AddAsync(refreshTokenEntity, cancellationToken);
        }
        catch (Exception ex)
        {
            return Error.Failure("Database", "Failed to save refresh token: " + ex.Message);
        }
        
        await unitOfWork.SaveChangesAsync();
        
        AuthResponseDto authResponseDto = new AuthResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            FullName = $"{user.FirstName} {user.LastName}"
        };
        
        return authResponseDto;
    }
    public async Task<ErrorOr<string>> RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var token = await tokenRepository.GetByTokenAsync(refreshToken, cancellationToken);
        
        if (token is null)
            return Error.NotFound(code: "RefreshToken", description: "RefreshToken not found");
        
        token.IsRevoked = true;

        var result = await tokenRepository.UpdateAsync(token, cancellationToken);
        if (result is null)
            return Error.Conflict(code: "RefreshToken", description: "RefreshToken cannot be revoked");
        
        await unitOfWork.SaveChangesAsync();
        
        return result.Token;
    }
}