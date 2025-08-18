using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IUserCategoriesRepository
    {
        Task<List<Category>> GetUserCategoriesAsync(int userId);
        Task<Category?> GetUserCategoryByIdAsync(int categoryId);
        Task AddUserCategoryAsync(Category category);
        Task RemoveUserCategoryByIdAsync(int categoryId);
        Task UpdateUserCategoryByIdAsync(int categoryId, string categoryName);
        Task<bool> CheckUserCategoryPermissionAsync(int categoryId, int userId);
    }
}
