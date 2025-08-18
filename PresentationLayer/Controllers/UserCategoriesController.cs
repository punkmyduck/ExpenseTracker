using ExpenseTracker.ApplicationLayer.DTO.Categories;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.InfrastructureLayer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCategoriesController : ControllerBase
    {
        private readonly IUserCategoriesService _userCategoriesService;

        public UserCategoriesController(IUserCategoriesService userCategoriesService)
        {
            _userCategoriesService = userCategoriesService;
        }

        /// <summary>
        /// Получить все категории пользователя.
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserCategories()
        {
            var userId = User.GetRequiredUserId();

            var result = await _userCategoriesService.GetUserCategoriesAsync(userId);

            if (result == null || !result.Any())
                return NotFound("No categories found for the user.");

            return Ok(result);
        }

        /// <summary>
        /// Создать новую категорию для пользователя.
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUserCategory([FromBody] UserCategoryCreationRequest category)
        {
            var userId = User.GetRequiredUserId();

            var createdCategory = await _userCategoriesService.CreateUserCategoryAsync(userId, category);

            return CreatedAtAction(nameof(GetUserCategories), new { id = createdCategory.CategoryId }, createdCategory);
        }

        /// <summary>
        /// Обновить категорию пользователя.
        /// </summary>
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUserCategory(int id, [FromBody] string categoryName)
        {
            var userId = User.GetRequiredUserId();

            await _userCategoriesService.UpdateUserCategoryAsync(id, userId, categoryName);

            return NoContent();
        }

        /// <summary>
        /// Удалить категорию пользователя.
        /// </summary>
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserCategory(int id)
        {
            var userId = User.GetRequiredUserId();

            await _userCategoriesService.RemoveUserCategoryAsync(id, userId);

            return NoContent();
        }
    }
}
