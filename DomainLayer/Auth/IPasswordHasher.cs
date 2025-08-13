using ExpenseTracker.DomainLayer.Auth.DTO;

namespace ExpenseTracker.DomainLayer.Auth
{
    public interface IPasswordHasher
    {
        Task<PasswordHashDto> GetPasswordHashAsync(string password);
    }
}
