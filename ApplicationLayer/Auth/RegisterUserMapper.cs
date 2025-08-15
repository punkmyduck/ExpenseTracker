using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Mapping.Interfaces;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class RegisterUserMapper : IRegisterUserMapper
    {
        public async Task<User> MapUserAsync(RegisterUserRequest registerUserRequest, PasswordHashDto passwordHash)
        {
            User user = new User
            {
                Username = registerUserRequest.Username,
                Email = registerUserRequest.Email,
                Userauthdatum = new Userauthdatum
                {
                    Passwordhash = passwordHash.PasswordHash,
                    Salt = passwordHash.Salt
                }
            };

            return await Task.FromResult(user);
        }
    }
}
