namespace ExpenseTracker.ApplicationLayer.Auth.DTO
{
    public class LoginUserRequest
    {
        public string EmailOrUsername { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
