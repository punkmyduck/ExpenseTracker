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
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public LoginUserService(
            IPasswordSaltHasher passwordHasher, 
            IUserRepository userRepository,
            IEmailValidator emailValidator,
            IUserAuthRepository userAuthRepository,
            IJwtTokenService jwtTokenService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _emailValidator = emailValidator;
            _userAuthRepository = userAuthRepository;
            _jwtTokenService = jwtTokenService;
            _refreshTokenRepository = refreshTokenRepository;
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

            var accessToken = _jwtTokenService.GenerateAccessToken(user, out var expiresAt);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            var refreshTokenModel = new Refreshtoken
            {
                Token = refreshToken.RefreshToken,
                Userid = user.Userid,
                Expiresat = refreshToken.ExpiresAt
            };

            await _refreshTokenRepository.AddAsync(refreshTokenModel);

            return new LoginUserResponse
            {
                AccessToken = accessToken,
                AccessTokenExpiresAt = expiresAt,
                RefreshToken = refreshToken.RefreshToken,
                RefreshTokenExpiresAt = refreshTokenModel.Expiresat.Value,
                UserId = user.Userid,
                UserName = user.Username,
                Email = user.Email
            };
        }
    }
}