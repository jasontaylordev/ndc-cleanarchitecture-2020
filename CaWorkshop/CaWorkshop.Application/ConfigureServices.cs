using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            return services;
        }
    }
}