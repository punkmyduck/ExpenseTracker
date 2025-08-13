using ExpenseTracker.ApplicationLayer.Interfaces.Repositories;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerContext _context;
        public UserRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetByUsername(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
