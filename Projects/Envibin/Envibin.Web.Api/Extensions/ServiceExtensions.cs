using Employment.Repo.Contracts;
using Employment.Services.Contracts;
using Employment.Services;
using Employment.Repo;

namespace Envibin.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) => 
            services.Configure<IISOptions>(options => 
            {  
            
            });

        public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services) { return services.AddScoped<IEmployeeRepositoryManager, EmployeeRepositoryManager>(); }
        public static IServiceCollection ConfigureServiceManager(this IServiceCollection services) { return services.AddScoped<IEmployeeServiceManager, EmployeeServiceManager>(); }
    }
}
