using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using System.Security.Cryptography;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class PasswordSaltHasher : IPasswordSaltHasher
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

        public Task<PasswordHashDto> GetPasswordWithFixedSaltHashAsync(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);

            return Task.FromResult(new PasswordHashDto
            {
                PasswordHash = Convert.ToBase64String(hashBytes),
                Salt = Convert.ToBase64String(saltBytes)
            });
        }
    }
}
