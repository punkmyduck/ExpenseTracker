using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.InfrastructureLayer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCategoriesController : ControllerBase
    {
        private readonly IUserCategoriesService _userCategoriesService;
        public UserCategoriesController(IUserCategoriesService userCategoriesService)
        {
            _userCategoriesService = userCategoriesService;
        }

        [Authorize]
        [HttpGet("usercategories")]
        public async Task<IActionResult> GetUserCategories()
        {
            var userId = User.GetRequiredUserId();
            var result = await _userCategoriesService.GetUserCategories(userId);
            if (result == null || !result.Any())
            {
                return NotFound("No categories found for the user.");
            }
            return Ok(result);
        }
    }
}
