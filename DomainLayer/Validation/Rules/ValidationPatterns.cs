namespace ExpenseTracker.DomainLayer.Validation.Rules
{
    public static class ValidationPatterns
    {
        public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public const string Password = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
        public const string UserName = @"^[a-zA-Z0-9_]{3,20}$";
    }
}
