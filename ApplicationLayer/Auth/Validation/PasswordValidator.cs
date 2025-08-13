using ExpenseTracker.DomainLayer.Auth.Validation;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Auth.Validation
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                return false;
            var hasLetter = Regex.IsMatch(password, @"[a-zA-Z]");
            var hasDigit = Regex.IsMatch(password, @"\d");
            return hasLetter && hasDigit;
        }
    }
}
