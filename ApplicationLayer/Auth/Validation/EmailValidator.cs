using ExpenseTracker.DomainLayer.Auth.Validation;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ApplicationLayer.Auth.Validation
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
