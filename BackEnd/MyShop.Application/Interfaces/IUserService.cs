using ErrorOr;
using MyShop.Application.DTOs.UserDTOs;

namespace MyShop.Application.Interfaces;

public interface IUserService
{
    Task<ErrorOr<AuthResponseDto>> Register(RegisterRequestDto registerRequestDto);
    Task<ErrorOr<AuthResponseDto>> Login(LoginRequestDto registerRequestDto);
    Task<ErrorOr<AuthResponseDto>> Refresh(RefreshRequestDto loginRequestDto);
}