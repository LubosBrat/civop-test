using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using CivopApp.Core;

namespace CivopApp
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Autofac IoC container
        private static IContainerProvider _containerProvider;

        // Autofac IoC container
        public IContainerProvider ContainerProvider => _containerProvider;


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterIoC();
        }

        private static void RegisterIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppDbContext>().As<IAppDbContext>().InstancePerRequest();
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}