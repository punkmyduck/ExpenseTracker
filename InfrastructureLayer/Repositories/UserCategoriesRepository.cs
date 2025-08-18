using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Exceptions;
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

        public async Task AddUserCategoryAsync(Category category)
        {
            if (await CheckExistingCategoryByNameAsync(category.Categoryname, category.Userid!.Value))
            {
                throw new UserCategoryAlreadyExistsException("Category with the same name already exists for this user.");
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckUserCategoryPermissionAsync(int categoryId, int userId)
        {
            var category = await GetUserCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            if (category.Userid != userId)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Category>> GetUserCategoriesAsync(int userId)
        {
            return await _context.Categories.AsNoTracking().Where(c => c.Userid == userId).ToListAsync();
        }

        public async Task<Category?> GetUserCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Categoryid == categoryId);
        }

        public async Task RemoveUserCategoryByIdAsync(int categoryId)
        {
            await _context.Categories.Where(c => c.Categoryid == categoryId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserCategoryByIdAsync(int categoryId, string categoryName)
        {
            await _context.Categories.Where(c => c.Categoryid == categoryId)
                .ExecuteUpdateAsync(c => c.SetProperty(c => c.Categoryname, categoryName));
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CheckExistingCategoryByNameAsync(string categoryName, int userId)
        {
            return await _context.Categories.AnyAsync(c => c.Categoryname == categoryName && c.Userid == userId);
        }
    }
}
