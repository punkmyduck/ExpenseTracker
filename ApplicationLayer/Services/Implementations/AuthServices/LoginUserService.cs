using ExpenseTracker.DomainLayer.Exceptions;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Validation;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.AuthServices
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IPasswordSaltHasherService _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidator _emailValidator;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IJwtProvider _jwtProvider;
        public LoginUserService(
            IPasswordSaltHasherService passwordHasher, 
            IUserRepository userRepository,
            IEmailValidator emailValidator,
            IUserAuthRepository userAuthRepository,
            IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _emailValidator = emailValidator;
            _userAuthRepository = userAuthRepository;
            _jwtProvider = jwtProvider;
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

            var token = _jwtProvider.GenerateToken(user);

            return new LoginUserResponse
            {
                Token = token
            };
        }
    }
}