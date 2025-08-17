namespace ExpenseTracker.ApplicationLayer.DTO.Auth
{
    public class PasswordHashDto
    {
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}
