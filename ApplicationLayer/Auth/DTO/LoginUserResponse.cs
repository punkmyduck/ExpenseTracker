namespace ExpenseTracker.ApplicationLayer.Auth.DTO
{
    public class LoginUserResponse
    {
        public string AccessToken { get; set; } = null!;
        public DateTime AccessTokenExpiresAt { get; set; }
        public string RefreshToken { get; set;} = null!;
        public DateTime RefreshTokenExpiresAt { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
