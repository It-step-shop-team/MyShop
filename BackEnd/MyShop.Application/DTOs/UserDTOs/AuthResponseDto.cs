namespace MyShop.Application.DTOs.UserDTOs;

public class AuthResponseDto
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
    public required string FullName { get; init; }

}