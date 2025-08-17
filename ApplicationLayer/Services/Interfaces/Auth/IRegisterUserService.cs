using ExpenseTracker.ApplicationLayer.DTO.Auth;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest registerUserRequest);
    }
}
