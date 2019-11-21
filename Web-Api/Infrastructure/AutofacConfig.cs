using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Web_Api.DAL;
using Web_Api.Services;

namespace Web_Api.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureConteiner()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);   
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataService>().As<IDataService>();
            builder.RegisterType<SqlLiteProvider>().As<IDataWorker>();
            var conteiner = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(conteiner);
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(conteiner));


        }
    }
}