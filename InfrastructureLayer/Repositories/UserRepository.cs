using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
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

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Userid == id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<User>?> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
