using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.InfrastructureLayer.Repositories;

namespace ExpenseTracker.InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuthHistoryRepository, UserAuthHistoryRepository>();
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
