using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetDefaultCategories();
    }
}
