using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
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
