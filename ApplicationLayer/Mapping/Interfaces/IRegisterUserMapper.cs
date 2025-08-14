using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Mapping.Interfaces
{
    public interface IRegisterUserMapper
    {
        Task<User?> MapUserAsync(RegisterUserRequest registerUserRequest, PasswordHashDto passwordHash);
    }
}
