using Employment.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Envibin.Web.DataStores
{
    public class EnviBinDbContext : DbContext
    {
        public EnviBinDbContext(DbContextOptions<EnviBinDbContext> options) : base(options)
        {
        }
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}