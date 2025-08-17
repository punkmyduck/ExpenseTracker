namespace ExpenseTracker.DomainLayer.Exceptions
{
    public class UserCategoriesNotFoundException : Exception
    {
        public UserCategoriesNotFoundException(string message) : base(message)
        {
            
        }
    }
}
