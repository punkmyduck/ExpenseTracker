using ExpenseTracker.DomainLayer.Auth;
using ExpenseTracker.DomainLayer.Auth.DTO;
using System.Security.Cryptography;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class BasePasswordHasher : IPasswordHasher
    {
        public Task<PasswordHashDto> GetPasswordHashAsync(string password)
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
    }
}
