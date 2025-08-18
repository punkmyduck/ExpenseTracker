using ExpenseTracker.DomainLayer.Validation;
using ExpenseTracker.DomainLayer.Validation.Rules;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Validation
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                return false;
            return Regex.IsMatch(password, ValidationPatterns.Password);
        }
    }
}
