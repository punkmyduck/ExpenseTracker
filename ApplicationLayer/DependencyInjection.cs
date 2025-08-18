using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Implementations;
using ExpenseTracker.ApplicationLayer.Services.Implementations.AuthServices;
using ExpenseTracker.ApplicationLayer.Services.Implementations.Categories;
using ExpenseTracker.ApplicationLayer.Services.Implementations.Transactions;
using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Categories;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions;
using ExpenseTracker.ApplicationLayer.Validation;
using ExpenseTracker.DomainLayer.Validation;

namespace ExpenseTracker.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IPasswordSaltHasherService, PasswordSaltHasherService>();
            services.AddScoped<IEmailValidator, EmailValidator>();
            services.AddScoped<IUserNameValidator, UserNameValidator>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<IRegisterUserMapper, RegisterUserMapper>();
            services.AddScoped<ICurrentUserProfileService, CurrentUserProfileService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IUserCategoriesService, UserCategoriesService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ITransactionCreatorService, TransactionCreatorService>();
            services.AddScoped<ITransactionCreationMapper, TransactionCreationMapper>();
            services.AddScoped<IUserCategoryMapper, UserCategoryMapper>();

            return services;
        }
    }
}
