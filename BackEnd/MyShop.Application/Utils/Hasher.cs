using System.Security.Cryptography;
using System.Text;

namespace MyShop.Application.Utils
{
    /// <summary>
    /// Статический класс для хэширования и проверки паролей.
    /// Содержит методы для генерации хэшей, проверки паролей и работы с солью.
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Хэширует пароль с использованием алгоритма SHA-256 и возвращает результат в Base64.
        /// </summary>
        /// <param name="password">Пароль для хэширования.</param>
        /// <returns>Хэш пароля в формате Base64.</returns>
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Проверяет, соответствует ли введенный пароль уже существующему хэшу.
        /// </summary>
        /// <param name="password">Пароль для проверки.</param>
        /// <param name="hashedPassword">Существующий хэш пароля для сравнения.</param>
        /// <returns><c>true</c>, если пароли совпадают; иначе <c>false</c>.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }

        /// <summary>
        /// Генерирует случайную соль длиной 32 байта и возвращает её в формате Base64.
        /// </summary>
        /// <returns>Случайная соль в формате Base64.</returns>
        public static string GenerateRandomSalt()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        /// <summary>
        /// Хэширует строку с добавлением соли с использованием SHA-256.
        /// </summary>
        /// <param name="input">Строка для хэширования.</param>
        /// <param name="salt">Соль для комбинирования с входной строкой.</param>
        /// <returns>Хэш строки с солью в формате Base64.</returns>
        public static string HashWithSalt(string input, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedInput = input + salt;
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}

