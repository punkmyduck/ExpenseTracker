﻿namespace ExpenseTracker.DomainLayer.Auth.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
