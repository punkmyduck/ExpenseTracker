using ExpenseTracker.DomainLayer.Validation;
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

            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
