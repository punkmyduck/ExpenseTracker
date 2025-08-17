using ExpenseTracker.ApplicationLayer.DTO.Categories;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface IUserCategoryMapper
    {
        Task<Category> Map(UserCategoryCreationRequest userCategoryCreationRequest, int userId);
    }
}
