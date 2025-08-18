using System.Security.Claims;

namespace ExpenseTracker.InfrastructureLayer.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Получить идентификатор пользователя из токена (claim "UserId").
        /// </summary>
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return null;

            if (int.TryParse(userIdClaim, out var userId))
                return userId;

            return null;
        }
        /// <summary>
        /// Получить идентификатор пользователя из токена (claim "UserId"). Если идентификатор не найден, выбрасывает исключение UnauthorizedAccessException.
        /// </summary>
        public static int GetRequiredUserId(this ClaimsPrincipal user)
        {
            var id = user.GetUserId();
            if (id == null)
                throw new UnauthorizedAccessException("User ID not found in token.");
            return id.Value;
        }
    }
}
