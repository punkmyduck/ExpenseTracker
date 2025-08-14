using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.InfrastructureLayer.Repositories;

namespace ExpenseTracker.InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
