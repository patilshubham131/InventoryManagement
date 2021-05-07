using Autofac;
using Autofac.Integration.WebApi;
using Inventory.BAL;
using Inventory.IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace InventoryAPI.App_Start
{
    public class TempConfig
    {
        static IContainer container;

        public static void Run()
        {
            Init(GlobalConfiguration.Configuration);
        }

        public static void Init(HttpConfiguration configuration)
        {
            Init(configuration,RegisterService(new ContainerBuilder()));
        }

        private static void Init(HttpConfiguration configuration, IContainer container)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterService(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>();

            container = builder.Build();

            return container;


        }

    }
}