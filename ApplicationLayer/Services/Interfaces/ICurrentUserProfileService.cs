using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface ICurrentUserProfileService
    {
        Task<User?> GetCurrentUserAsync(int userId);
    }
}
