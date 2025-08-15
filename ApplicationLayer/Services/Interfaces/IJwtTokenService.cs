using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
using System.Security.Claims;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user, out DateTime expiresAt, IEnumerable<Claim>? extraClaims = null);
        RefreshTokenDto GenerateRefreshToken();
    }
}
