using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
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
