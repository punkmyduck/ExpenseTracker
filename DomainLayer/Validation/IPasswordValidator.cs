namespace ExpenseTracker.DomainLayer.Validation
{
    public interface IPasswordValidator
    {
        bool IsValid(string password);
    }
}
