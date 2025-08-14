using ExpenseTracker.ApplicationLayer.Auth.DTO;
using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.Auth;
using ExpenseTracker.DomainLayer.Auth.Validation;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordSaltHasher _passwordHasher;
        private readonly IEmailValidator _emailValidator;
        private readonly IUserNameValidator _userNameValidator;
        private readonly IPasswordValidator _passwordValidator;
        
        public RegisterUserService(
            IUserRepository userRepository, 
            IPasswordSaltHasher passwordHasher, 
            IEmailValidator emailValidator, 
            IUserNameValidator userNameValidator, 
            IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailValidator = emailValidator;
            _userNameValidator = userNameValidator;
            _passwordValidator = passwordValidator;
        }
        public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserMapper registerUserRequest)
        {
            ValidateData(registerUserRequest);
            await CheckExistingUsers(registerUserRequest);

            PasswordHashDto passwordHash = await _passwordHasher.GetPasswordSaltHashAsync(registerUserRequest.Password);

            User newUser = new User
            {
                Username = registerUserRequest.Username,
                Email = registerUserRequest.Email,
                Userauthdatum = new Userauthdatum
                {
                    Passwordhash = passwordHash.PasswordHash ?? throw new Exception(),
                    Salt = passwordHash.Salt ?? throw 
                }
            };

            await _userRepository.AddAsync(newUser);

            return new RegisterUserResponse { UserId = newUser.Userid };
        }

        private async Task CheckExistingUsers(RegisterUserMapper registerUserRequest)
        {
            if (await _userRepository.GetByEmailAsync(registerUserRequest.Email) != null)
            {
                throw new UserAlreadyExistsException(registerUserRequest.Email, "Email");
            }
            if (await _userRepository.GetByUsername(registerUserRequest.Username) != null)
            {
                throw new UserAlreadyExistsException(registerUserRequest.Username, "Username");
            }
        }

        private void ValidateData(RegisterUserMapper registerUserRequest)
        {
            if (!_emailValidator.IsValid(registerUserRequest.Email))
            {
                throw new ValidationException("Invalid email");
            }

            if (!_userNameValidator.IsValid(registerUserRequest.Username))
            {
                throw new ValidationException("Invalid username");
            }

            if (!_passwordValidator.IsValid(registerUserRequest.Password))
            {
                throw new ValidationException("Invalid password");
            }
        }
    }
}
