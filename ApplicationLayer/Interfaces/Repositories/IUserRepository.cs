using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsername(string username);
        Task AddAsync(User user);
    }
}
