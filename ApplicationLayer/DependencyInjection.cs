using ExpenseTracker.ApplicationLayer.Auth;
using ExpenseTracker.ApplicationLayer.Auth.Validation;
using ExpenseTracker.ApplicationLayer.Mapping.Interfaces;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.Auth.Validation;

namespace ExpenseTracker.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IPasswordSaltHasher, PasswordSaltHasher>();
            services.AddScoped<IEmailValidator, EmailValidator>();
            services.AddScoped<IUserNameValidator, UserNameValidator>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<IRegisterUserMapper, RegisterUserMapper>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
