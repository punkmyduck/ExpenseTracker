using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories
{
    public interface IUserCategoriesService
    {
        Task<List<Category>?> GetUserCategories(int userId);
    }
}
