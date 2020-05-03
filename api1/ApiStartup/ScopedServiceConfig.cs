using api1.Interfaces;
using api1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api1.ApiStartup
{
    public static class ScopedServiceConfig
    {
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            ResolveServices(services);
        }

        private static void ResolveServices(this IServiceCollection services)
        {
            services.AddTransient<IInterestRateService, InterestRateService>();
        }
    }
}
