using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
