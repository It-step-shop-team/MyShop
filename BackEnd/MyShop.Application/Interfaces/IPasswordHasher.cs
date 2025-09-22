namespace MyShop.Application.Interfaces;

public interface IPasswordHasher
{
    string Ganerate(string password);
    bool Verify(string password, string hashedPassword);
}