namespace ExpenseTracker.ApplicationLayer.Auth.DTO
{
    public class PasswordHashDto
    {
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}
