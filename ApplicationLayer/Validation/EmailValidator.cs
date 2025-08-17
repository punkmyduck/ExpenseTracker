using ExpenseTracker.DomainLayer.Validation;
using ExpenseTracker.DomainLayer.Validation.Rules;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Validation
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return Regex.IsMatch(email, ValidationPatterns.EmailPattern);
        }
    }
}
