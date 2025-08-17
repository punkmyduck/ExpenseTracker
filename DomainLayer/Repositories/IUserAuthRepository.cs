using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IUserAuthRepository
    {
        Task<Userauthdatum?> GetByIdAsync(int id);
    }
}
