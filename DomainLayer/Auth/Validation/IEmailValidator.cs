namespace ExpenseTracker.DomainLayer.Auth.Validation
{
    public interface IEmailValidator
    {
        bool IsValid(string email);
    }
}
