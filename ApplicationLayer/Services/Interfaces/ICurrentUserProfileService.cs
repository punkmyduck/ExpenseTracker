using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface ICurrentUserProfileService
    {
        Task<User?> GetCurrentUserAsync(int userId);
    }
}
