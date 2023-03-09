using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using TARge21Shop.Data;
using TARge21Shop.SpaceshipTest.Macros;

namespace TARge21Shop.SpaceshipTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; }
        protected TestBase() 
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacros
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services) 
        {
            services.AddDbContext<TARge21ShopContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }
        private  void RegisterMacros(IServiceCollection services) 
        {
            var macroBaseType = typeof(IMacro);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros) 
            { 
                services.AddSingleton(macro);
            }
        }
    }
}
