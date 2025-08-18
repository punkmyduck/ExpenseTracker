using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.InfrastructureLayer.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet("defaultcategories")]
        public async Task<IActionResult> GetDefaultCategories()
        {
            var result = await _categoriesService.GetDefaultCategories();
            return Ok(result);
        }
    }
}
