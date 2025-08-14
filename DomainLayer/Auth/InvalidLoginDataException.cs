namespace ExpenseTracker.DomainLayer.Auth
{
    public class InvalidLoginDataException : Exception
    {
        public InvalidLoginDataException(string message) : base(message)
        { }
    }
}
