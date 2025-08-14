using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.Auth;
using ExpenseTracker.DomainLayer.Auth.Validation;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IPasswordSaltHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidator _emailValidator;
        public LoginUserService(
            IPasswordSaltHasher passwordHasher, 
            IUserRepository userRepository,
            IEmailValidator emailValidator)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _emailValidator = emailValidator;
        }
        public async Task<LoginUserResponse> ExecuteAsync(LoginUserRequest loginRequest)
        {
            var user = _emailValidator.IsValid(loginRequest.Email)
                ? await _userRepository.GetByEmailAsync(loginRequest.Email)
                : await _userRepository.GetByUsername(loginRequest.Username);

            if (user == null)
            {
                throw new InvalidLoginDataException("Invalid login or password");
            }

            if (!_passwordHasher.VerifyPassword(loginRequest.Password, user.Passwordhash, user.Salt))
            {
                throw new InvalidLoginDataException("Invalid login or password");
            }

            return new LoginUserResponse();
        }
    }
}
