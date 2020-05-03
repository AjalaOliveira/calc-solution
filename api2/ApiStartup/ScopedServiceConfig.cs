using api2.Interfaces;
using api2.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api2.ApiStartup
{
    public static class ScopedServiceConfig
    {
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            ResolveServices(services);
        }

        private static void ResolveServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculateInterestService, CalculateInterestService>();
            services.AddTransient<IShowCodeService, ShowCodeService>();
        }
    }
}
