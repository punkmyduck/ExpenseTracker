using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface ICategoriesRepository
    {
        Task<List<Category>?> GetDefaultCategoriesAsync();
    }
}
