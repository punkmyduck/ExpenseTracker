using ExpenseTracker.ApplicationLayer.Auth.DTO;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface IPasswordSaltHasher
    {
        Task<PasswordHashDto> GetPasswordSaltHashAsync(string password);
        Task<PasswordHashDto> GetPasswordWithFixedSaltHashAsync(string password, string salt);
    }
}
