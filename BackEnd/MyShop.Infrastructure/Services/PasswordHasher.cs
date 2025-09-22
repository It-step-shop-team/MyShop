using MyShop.Application.Interfaces;

namespace MyShop.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Ganerate(string password) => 
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}