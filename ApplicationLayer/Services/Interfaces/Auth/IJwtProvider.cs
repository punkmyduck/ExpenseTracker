using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
