using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOptions _options;
        private readonly byte[] _keyBytes;
        public JwtTokenService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
            _keyBytes = Encoding.UTF8.GetBytes(_options.Key);
        }
        public string GenerateAccessToken(User user, out DateTime expiresAt, IEnumerable<Claim>? extraClaims = null)
        {
            var now = DateTime.Now;
            expiresAt = now.AddMinutes(_options.AccessTokenLifetimeMinutes);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Userid.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (extraClaims != null) claims.AddRange(extraClaims);

            var creds = new SigningCredentials(new SymmetricSecurityKey(_keyBytes), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: expiresAt,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public RefreshTokenDto GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            var token = Convert.ToBase64String(bytes);
            var exp = DateTime.Now.AddDays(_options.RefreshTokenLifetimeDays);
            return new RefreshTokenDto { RefreshToken = token, ExpiresAt = exp };
        }
    }
}
