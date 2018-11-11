using Autofac;
using Module = Autofac.Module;

namespace CM.Services.Exchange.Infrastracture.DI
{
    public class InfrastractureAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register repositories
            //builder
            //    .RegisterAssemblyTypes(typeof(ConfigRepository).GetTypeInfo().Assembly)
            //    .AsImplementedInterfaces()
            //    .AsClosedTypesOf(typeof(Repository<,>));
        }
    }
}