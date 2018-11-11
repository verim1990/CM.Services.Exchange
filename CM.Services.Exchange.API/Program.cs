using CM.Services.Exchange.Infrastracture.Contexts;
using CM.Shared.Kernel.Others.Sql;
using CM.Shared.Web.Others.Kong;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CM.Services.Exchange.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .RegisterKong()
                .RegisterSql<ApplicationContext>(async (context, services) => await context.Seed())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
