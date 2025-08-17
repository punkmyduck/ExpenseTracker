using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth;
using System.Security.Cryptography;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.AuthServices
{
    public class PasswordSaltHasherService : IPasswordSaltHasherService
    {
        public Task<PasswordHashDto> GetPasswordSaltHashAsync(string password)
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);

            return Task.FromResult(new PasswordHashDto
            {
                PasswordHash = Convert.ToBase64String(hashBytes),
                Salt = Convert.ToBase64String(saltBytes)
            });
        }

        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] hashBytes = HashPassword(password, saltBytes);

            return Convert.ToBase64String(hashBytes) == storedHash;
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(32);
        }
    }
}
