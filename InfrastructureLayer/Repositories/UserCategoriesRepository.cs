using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class UserCategoriesRepository : IUserCategoriesRepository
    {
        private readonly ExpenseTrackerContext _context;
        public UserCategoriesRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task<List<Category>?> GetUserCategoriesAsync(int userId)
        {
            return await _context.Categories.AsNoTracking().Where(c => c.Userid == userId).ToListAsync();
        }
    }
}
