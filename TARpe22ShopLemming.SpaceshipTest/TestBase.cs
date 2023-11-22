using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopLemming.ApplicationServices.Services;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;
using TARpe22ShopLemming.SpaceshipTest.Macros;

namespace TARpe22ShopLemming.SpaceshipTest
{
    public abstract class TestBase
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected TestBase() 
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose() { }

        protected T Svc<T>()
        {
            return ServiceProvider.GetService<T>();
        }
        protected T Macro<T>() where T : IMacros
        {
            return ServiceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
            services.AddScoped<IFilesServices, FilesServices>();
            services.AddScoped<IWebHost>();

            services.AddDbContext<TARpe22ShopLemmingContext>(x =>
                {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                }
                );
            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {

            }
        }
    }
}
