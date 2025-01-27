using CreditCardAllowedActions.Infrastructure.Persistence.Repositories;
using CreditCardAllowedActions.Infrastructure.Persistence.Repositories.Interfaces;

namespace CreditCardAllowedActions.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<ICardServiceRepository, CardServiceRepository>();

            return services;
        }
    }
}
