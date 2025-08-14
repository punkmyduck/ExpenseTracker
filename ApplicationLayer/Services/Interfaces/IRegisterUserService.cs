using ExpenseTracker.ApplicationLayer.Auth.DTO;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest registerUserRequest);
    }
}
