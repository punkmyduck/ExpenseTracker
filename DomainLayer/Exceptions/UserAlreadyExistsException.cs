namespace ExpenseTracker.DomainLayer.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string param)
        : base($"User with '{param}' already exists")
        { }

        public UserAlreadyExistsException(string param, string paramName)
        : base($"User with {paramName} : '{param}' already exists")
        { }
    }
}
