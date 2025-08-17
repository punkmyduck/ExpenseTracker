using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IUserCategoriesRepository
    {
        Task<List<Category>?> GetUserCategoriesAsync(int userId);
    }
}
