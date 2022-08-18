using Envibin.Web.DataStores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Envibin.Web.Api.Factories
{
    public class EnvibinContextFactory : IDesignTimeDbContextFactory<EnviBinDbContext>
    {
        public EnviBinDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EnviBinDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Envibin.Web.Api"));

            return new EnviBinDbContext(builder.Options);
        }
    }
}
