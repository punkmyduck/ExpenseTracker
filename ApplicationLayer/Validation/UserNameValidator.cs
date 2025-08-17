using ExpenseTracker.DomainLayer.Validation;
using ExpenseTracker.DomainLayer.Validation.Rules;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Validation
{
    public class UserNameValidator : IUserNameValidator
    {
        public bool IsValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;
            return Regex.IsMatch(username, ValidationPatterns.UserName);
        }
    }
}
