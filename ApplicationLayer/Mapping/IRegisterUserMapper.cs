using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface IRegisterUserMapper
    {
        Task<User> MapUserAsync(RegisterUserRequest registerUserRequest, PasswordHashDto passwordHash);
    }
}
