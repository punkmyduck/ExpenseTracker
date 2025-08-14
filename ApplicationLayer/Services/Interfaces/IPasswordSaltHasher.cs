using ExpenseTracker.ApplicationLayer.Auth.DTO;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface IPasswordSaltHasher
    {
        Task<PasswordHashDto> GetPasswordSaltHashAsync(string password);
        bool VerifyPassword(string password, string storedHash, string storedSalt);
    }
}
