using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ICurrentUserProfileService _currentUserProfileService;

        public TestController(
            ICurrentUserProfileService currentUserProfileService)
        {
            _currentUserProfileService = currentUserProfileService;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var user = await _currentUserProfileService.GetCurrentUserAsync(userId);

            return Ok(user);
        }
    }
}
