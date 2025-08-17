using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping.Interfaces
{
    public interface IRegisterUserMapper
    {
        Task<User> MapUserAsync(RegisterUserRequest registerUserRequest, PasswordHashDto passwordHash);
    }
}
