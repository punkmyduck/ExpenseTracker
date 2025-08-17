using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Providers.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
