using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ExpenseTrackerContext _context;
        public CategoriesRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task<List<Category>?> GetDefaultCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().Where(c => c.Categorytype == 'd').ToListAsync();
        }
    }
}
