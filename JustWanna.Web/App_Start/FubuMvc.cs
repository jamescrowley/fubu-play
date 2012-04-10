using System.Collections.Generic;
using System.Web.Routing;
using Bottles;
using Cassette.Stylesheets;
using Cassette.Views;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using JustWanna.Web.Infrastructure;
using StructureMap;

namespace JustWanna.Web.App_Start
{
    public static class AppStartFubuMvc
    {
        public static void Start()
        {
            var container = new Container();
            container.Configure(c =>
            {
                c.Scan(i =>
                           {
                               i.TheCallingAssembly();
                               PackageRegistry.PackageAssemblies.Each(i.Assembly);
                               i.LookForRegistries();
                           });
            });
            // FubuApplication "guides" the bootstrapping of the FubuMVC
            // application
            FubuApplication.For<FubuMvcRegistry>() // ConfigureFubuMVC is the main FubuRegistry
                // for this application.  FubuRegistry classes 
                // are used to register conventions, policies,
                // and various other parts of a FubuMVC application


                // FubuMVC requires an IoC container for its own internals.
                // In this case, we're using a brand new StructureMap container,
                // but FubuMVC just adds configuration to an IoC container so
                // that you can use the native registration API's for your
                // IoC container for the rest of your application

                .StructureMap(container)
                .Bootstrap();

            // Ensure that no errors occurred during bootstrapping
            PackageRegistry.AssertNoFailures();
        }
    }
}