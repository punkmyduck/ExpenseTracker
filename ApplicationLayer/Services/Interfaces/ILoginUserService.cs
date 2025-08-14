using ExpenseTracker.ApplicationLayer.Auth.DTO;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces
{
    public interface ILoginUserService
    {
        Task<LoginUserResponse> ExecuteAsync(LoginUserRequest loginRequest);
    }
}
