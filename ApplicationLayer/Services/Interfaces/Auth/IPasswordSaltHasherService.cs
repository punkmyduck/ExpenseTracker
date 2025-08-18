using ExpenseTracker.ApplicationLayer.DTO.Auth;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth
{
    public interface IPasswordSaltHasherService
    {
        Task<PasswordHashDto> GetPasswordSaltHashAsync(string password);
        bool VerifyPassword(string password, string storedHash, string storedSalt);
    }
}
