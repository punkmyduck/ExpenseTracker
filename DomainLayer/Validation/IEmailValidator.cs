namespace ExpenseTracker.DomainLayer.Validation
{
    public interface IEmailValidator
    {
        bool IsValid(string email);
    }
}
