using CM.Shared.Kernel.Application.Settings;
using CM.Shared.Kernel.Others.Kong;
using CM.Shared.Kernel.Others.Sql;
using CM.Shared.Kernel.Others.Swagger;

namespace CM.Services.Exchange.API
{
    public class AppSettings
    {
        public GlobalSettings Global { get; set; } = new GlobalSettings();

        public LocalSettings Local { get; set; } = new LocalSettings();

        public object GetPublicSettings()
        {
            return new
            {
                ServiceName = Global.Exchange.Name
            };
        }
    }

    public class GlobalSettings
    {
        public SqlSettings Sql { get; set; } = new SqlSettings();

        public KongSettings Kong { get; set; } = new KongSettings();

        public ServiceSettings Web { get; set; } = new ServiceSettings();

        public ServiceSettings Identity { get; set; } = new ServiceSettings();

        public ServiceSettings Exchange { get; set; } = new ServiceSettings();

        public ServiceSettings Wallet { get; set; } = new ServiceSettings();

        public ServiceSettings WalletViews { get; set; } = new ServiceSettings();
    }

    public class LocalSettings
    {
        public SwaggerSettings Swagger { get; set; }

        public KongServiceSettings Kong { get; set; }

        public SqlContextSettings Sql { get; set; }
    }
}