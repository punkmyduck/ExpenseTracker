using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<List<Category>> GetDefaultCategories()
        {
            return await _categoriesRepository.GetDefaultCategoriesAsync()
                   ?? new List<Category>();
        }
    }
}
