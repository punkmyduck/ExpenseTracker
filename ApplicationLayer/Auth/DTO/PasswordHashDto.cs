namespace ExpenseTracker.ApplicationLayer.Auth.DTO
{
    public class PasswordHashDto
    {
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
