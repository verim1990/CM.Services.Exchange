using CM.Services.Exchange.Infrastracture.Contexts;
using CM.Services.Exchange.Infrastracture.DI;
using CM.Shared.Kernel.Others.Sql;
using CM.Shared.Web;
using CM.Shared.Web.Others.FluentValidation;
using CM.Shared.Web.Others.Kong;
using CM.Shared.Web.Others.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CM.Services.Exchange.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = Configuration.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        public AppSettings AppSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .Initialize<AppSettings>(Configuration, AppSettings.Global.Exchange)
                .IncludeCors(AppSettings.Global.Web.HttpsUrl)
                .IncludeAuthenticationForAPI(AppSettings.Global.Exchange.Name, AppSettings.Global.Identity.LocalUrl)
                .IncludeKong(AppSettings.Global.Kong, AppSettings.Local.Kong, AppSettings.Global.Exchange)
                .IncludeSqlServer<ApplicationContext>(AppSettings.Global.Sql, AppSettings.Local.Sql, true)
                .IncludeSwagger(AppSettings.Local.Swagger, AppSettings.Global.Identity.HttpsUrl)
                //.IncludeMediator(typeof(AddDictionaryItemCommandHandler));
                .AddMvc()
                .IncludeFluentValidation(/* , RegisterCommandValidator */)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services.RegisterModules(new InfrastractureAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCorsForCM()
                .UseSwaggerForCM(AppSettings.Local.Swagger)
                .UseAuthenticationForCM()
                .UseResponseWrapperForCM()
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
