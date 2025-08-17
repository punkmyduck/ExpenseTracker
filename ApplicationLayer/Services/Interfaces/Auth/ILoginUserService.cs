using ExpenseTracker.ApplicationLayer.DTO.Auth;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth
{
    public interface ILoginUserService
    {
        Task<LoginUserResponse> ExecuteAsync(LoginUserRequest loginRequest);
    }
}
