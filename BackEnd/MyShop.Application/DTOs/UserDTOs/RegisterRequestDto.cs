namespace MyShop.Application.DTOs.UserDTOs;

public class RegisterRequestDto
{
    public required string Login { get; init; }
    public required string Password { get; init; }
    public required string Email { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public required string PhoneNumber { get; init; }
    public string? Address { get; init; }
}