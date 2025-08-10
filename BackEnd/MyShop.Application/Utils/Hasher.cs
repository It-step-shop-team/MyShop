using System.Security.Cryptography;
using System.Text;

namespace MyShop.Application.Utils
{
    public static class Hasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }

        public static string GenerateRandomSalt()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public static string HashWithSalt(string input, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedInput = input + salt;
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
