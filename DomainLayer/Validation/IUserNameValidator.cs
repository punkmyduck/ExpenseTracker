namespace ExpenseTracker.DomainLayer.Validation
{
    public interface IUserNameValidator
    {
        bool IsValid(string username);
    }
}
