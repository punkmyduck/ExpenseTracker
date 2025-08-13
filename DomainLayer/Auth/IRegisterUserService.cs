using ExpenseTracker.DomainLayer.Auth.DTO;

namespace ExpenseTracker.DomainLayer.Auth
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest registerUserRequest);
    }
}
