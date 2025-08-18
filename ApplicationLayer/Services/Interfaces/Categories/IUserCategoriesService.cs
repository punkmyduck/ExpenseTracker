using ExpenseTracker.ApplicationLayer.DTO.Categories;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories
{
    public interface IUserCategoriesService
    {
        Task<List<GetUserCategoryDto>> GetUserCategoriesAsync(int userId);
        Task<UserCategoryCreationResponse> CreateUserCategoryAsync(int userId, UserCategoryCreationRequest userCategoryCreationRequest);
        Task RemoveUserCategoryAsync(int categoryId, int userId);
        Task UpdateUserCategoryAsync(int categoryId, int userId, string categoryName);
    }
}
