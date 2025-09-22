using ErrorOr;
using MyShop.Application.DTOs.UserDTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;

namespace MyShop.Application.Services;

public class UserService(IPasswordHasher hasher, IUserRepository userRepository, ITokenService tokenService) : IUserService
{
    public async Task<ErrorOr<AuthResponseDto>> Register(RegisterRequestDto registerRequestDto)
    {
        var hashedPassword = hasher.Ganerate(registerRequestDto.Password);

        ApplicationUser user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            Login = registerRequestDto.Login,
            PasswordHash = hashedPassword,
            RoleId = Guid.Parse("f6f2ad3b-3ec3-4c46-9343-5b4b76f2c8a3"),
            Email = registerRequestDto.Email,
            FirstName = registerRequestDto.FirstName,
            LastName = registerRequestDto.LastName,
            PhoneNumber = registerRequestDto.PhoneNumber,
            Address = registerRequestDto.Address,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var result = await userRepository.AddAsync(user);

        if (result is null)
            return Error.Conflict(code:"User", description:"User create error.");
        
        return await tokenService.GenerateTokensAsync(result.Id);
    }

    public async Task<ErrorOr<AuthResponseDto>> Login(LoginRequestDto loginRequestDto)
    {
        var user = await userRepository.GetByLoginAsync(loginRequestDto.Login);
        if (user is null)
            user = await userRepository.GetByEmailAsync(loginRequestDto.Login);
        if (user is null)
            return Error.Conflict(code:"Login.User", description:"User with transmitted login or mail not found.");

        if (!hasher.Verify(loginRequestDto.Password, user.PasswordHash))
            return Error.Conflict(code:"Login.User.Password", description:"Incorrect password.");
        
        return await tokenService.GenerateTokensAsync(user.Id);
    }

    public async Task<ErrorOr<AuthResponseDto>> Refresh(RefreshRequestDto loginRequestDto)
    {
        return await tokenService.RefreshTokensAsync(loginRequestDto.RefreshToken);
    }
}