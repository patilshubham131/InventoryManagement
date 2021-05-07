using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Inventory.IBL;
using Inventory.BAL;

namespace InventoryAPI.App_Start
{
    public class AutoFacWebApiConfig
    {
        public static IContainer container;

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