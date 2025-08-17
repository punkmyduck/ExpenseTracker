using ExpenseTracker.ApplicationLayer.DTO.Categories;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Exceptions;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public class UserCategoryMapper : IUserCategoryMapper
    {
        public Task<Category> Map(UserCategoryCreationRequest userCategoryCreationRequest, int userId)
        {
            if (string.IsNullOrEmpty(userCategoryCreationRequest.CategoryName))
                throw new ValidationException("Category name cannot be null or empty.");

            Category category = new Category
            {
                Categoryname = userCategoryCreationRequest.CategoryName,
                Categorytype = 'u',
                Userid = userId
            };

            return Task.FromResult(category);
        }
    }
}
