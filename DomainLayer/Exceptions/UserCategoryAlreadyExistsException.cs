namespace ExpenseTracker.DomainLayer.Exceptions
{
    public class UserCategoryAlreadyExistsException : Exception
    {
        public UserCategoryAlreadyExistsException(string message) : base(message)
        {
            
        }
    }
}
