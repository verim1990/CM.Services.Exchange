using CM.Services.Exchange.Infrastracture.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading.Tasks;

namespace CM.Services.Exchange.Infrastracture.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaNames.Default);

            // Domain
        }
    }

    public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer("Server=tcp:127.0.0.1,5433;Database=CM_Services_ExchangeDb;User Id=SA;Password=Test1990!;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }


    public static class ApplicationContextExtensions
    {
        public static async Task Seed(this ApplicationContext context)
        {
            await Task.CompletedTask;
        }
    }
}