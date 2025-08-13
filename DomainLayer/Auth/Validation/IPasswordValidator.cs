namespace ExpenseTracker.DomainLayer.Auth.Validation
{
    public interface IPasswordValidator
    {
        bool IsValid(string password);
    }
}
