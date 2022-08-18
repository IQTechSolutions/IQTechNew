using Contracts.Logger;
using IqtFramework.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace IqtFramework.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIqTechFrameworkServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }           
    }
}
