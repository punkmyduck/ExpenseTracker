using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.Auth;
using ExpenseTracker.DomainLayer.Auth.Validation;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IPasswordSaltHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidator _emailValidator;
        private readonly IUserAuthRepository _userAuthRepository;
        public LoginUserService(
            IPasswordSaltHasher passwordHasher, 
            IUserRepository userRepository,
            IEmailValidator emailValidator,
            IUserAuthRepository userAuthRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _emailValidator = emailValidator;
            _userAuthRepository = userAuthRepository;
        }
        public async Task<LoginUserResponse> ExecuteAsync(LoginUserRequest loginRequest)
        {
            var user = _emailValidator.IsValid(loginRequest.EmailOrUsername)
                ? await _userRepository.GetByEmailAsync(loginRequest.EmailOrUsername)
                : await _userRepository.GetByUsername(loginRequest.EmailOrUsername);

            if (user == null) 
                throw new InvalidLoginDataException("Invalid login or password");

            Userauthdatum? userAuthData = await _userAuthRepository.GetByIdAsync(user.Userid);

            if (!_passwordHasher.VerifyPassword(loginRequest.Password, userAuthData!.Passwordhash, userAuthData.Salt)) 
                throw new InvalidLoginDataException("Invalid login or password");

            return new LoginUserResponse();
        }
    }
}