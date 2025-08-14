using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Mapping.Interfaces;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class RegisterUserMapper : IRegisterUserMapper
    {
        public Task<User?> MapUserAsync(RegisterUserRequest registerUserRequest, PasswordHashDto passwordHash)
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
            return Task<User?>.FromResult(user);
        }
    }
}
