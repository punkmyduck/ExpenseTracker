using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Repositories.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<Userauthdatum?> GetByIdAsync(int id);
    }
}
