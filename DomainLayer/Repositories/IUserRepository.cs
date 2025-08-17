using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsername(string username);
        Task AddAsync(User user);
        Task<List<User>?> GetUsers();
    }
}
