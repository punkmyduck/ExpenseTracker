using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly ExpenseTrackerContext _context;
        public UserAuthRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task<Userauthdatum?> GetByIdAsync(int id)
        {
            return await _context.Userauthdata.FirstOrDefaultAsync(u => u.Userid == id);
        }
    }
}
