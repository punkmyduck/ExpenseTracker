namespace ExpenseTracker.DomainLayer.Auth.Validation
{
    public interface IUserNameValidator
    {
        bool IsValid(string username);
    }
}
