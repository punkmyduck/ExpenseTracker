namespace ExpenseTracker.ApplicationLayer.DTO.Auth
{
    public class LoginUserRequest
    {
        public string EmailOrUsername { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
