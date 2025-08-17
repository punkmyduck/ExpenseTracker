using ExpenseTracker.DomainLayer.Validation;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Validation
{
    public class UserNameValidator : IUserNameValidator
    {
        public bool IsValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;
            var pattern = @"^[a-zA-Z0-9]{3,20}$";
            return Regex.IsMatch(username, pattern);
        }
    }
}
