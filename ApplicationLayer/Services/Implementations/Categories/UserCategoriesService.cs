using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Categories
{
    public class UserCategoriesService : IUserCategoriesService
    {
        private readonly IUserCategoriesRepository _userCategoriesRepository;
        public UserCategoriesService(IUserCategoriesRepository userCategoriesRepository)
        {
            _userCategoriesRepository = userCategoriesRepository;
        }
        public async Task<List<Category>?> GetUserCategories(int userId)
        {
            return await _userCategoriesRepository.GetUserCategoriesAsync(userId);
        }
    }
}
