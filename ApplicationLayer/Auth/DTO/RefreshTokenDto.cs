namespace ExpenseTracker.ApplicationLayer.Auth.DTO
{
    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}
