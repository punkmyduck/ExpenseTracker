using ExpenseTracker.ApplicationLayer.DTO.Categories;
using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Categories
{
    public class UserCategoriesService : IUserCategoriesService
    {
        private readonly IUserCategoriesRepository _userCategoriesRepository;
        private readonly IUserCategoryMapper _userCategoryMapper;
        public UserCategoriesService(
            IUserCategoriesRepository userCategoriesRepository,
            IUserCategoryMapper userCategoryMapper)
        {
            _userCategoriesRepository = userCategoriesRepository;
            _userCategoryMapper = userCategoryMapper;
        }

        public async Task<UserCategoryCreationResponse> CreateUserCategoryAsync(int userId, UserCategoryCreationRequest userCategoryCreationRequest)
        {
            var category = await _userCategoryMapper.Map(userCategoryCreationRequest, userId);

            await _userCategoriesRepository.AddUserCategoryAsync(category);

            return new UserCategoryCreationResponse
            {
                CategoryId = category.Categoryid,
                CategoryName = category.Categoryname
            };
        }

        public async Task<List<GetUserCategoryDto>> GetUserCategoriesAsync(int userId)
        {
            var categories = await _userCategoriesRepository.GetUserCategoriesAsync(userId);

            List<GetUserCategoryDto> result = new();

            foreach (var c in categories)
            {
                result.Add(new GetUserCategoryDto
                {
                    CategoryId = c.Categoryid,
                    CategoryName = c.Categoryname,
                    UserId = c.Userid!.Value
                });
            }

            return result;
        }

        public async Task RemoveUserCategoryAsync(int categoryId, int userId)
        {
            if (!await _userCategoriesRepository.CheckUserCategoryPermissionAsync(categoryId, userId))
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this category.");
            }
            await _userCategoriesRepository.RemoveUserCategoryByIdAsync(categoryId);
        }

        public async Task UpdateUserCategoryAsync(int categoryId, int userId, string categoryName)
        {
            if (!await _userCategoriesRepository.CheckUserCategoryPermissionAsync(categoryId, userId))
            {
                throw new UnauthorizedAccessException("You do not have permission to update this category.");
            }
            await _userCategoriesRepository.UpdateUserCategoryByIdAsync(categoryId, categoryName);
        }
    }
}
