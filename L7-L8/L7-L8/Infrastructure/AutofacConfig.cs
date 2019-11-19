using Autofac;
using Autofac.Integration.Mvc;
using L7_L8.DAL;
using L7_L8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L7_L8.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DataSqliteRepository>().As<IDataRepository>();
            builder.RegisterType<DataService>().As<IDataService>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}