using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebServer.Controllers;

namespace WebServer.Infrastructure
{
    class ServiceLocator
    {
        private static Dictionary<Type, object> services = new Dictionary<Type, object>();
        public static string RootDir { set; get; }
        public static string ViewsDir { set; get; }

        public static void Register<T>(Type serviceType)
        {
            var serviceParametrs = serviceType.GetConstructors().First().GetParameters();
            if(serviceParametrs.Length == 0)
            {
                services[typeof(T)] = Activator.CreateInstance(serviceType);
            }
            else
            {
                var depObj = BuildDependency(serviceParametrs);
                services[typeof(T)] = Activator.CreateInstance(serviceType, depObj);
            }
        }

        private static object[] BuildDependency(ParameterInfo[] parameters)
        {
            var dependencyObjects = new List<object>();
            foreach (var param in parameters)
            {
                if (param.Name == "rootDir")
                {
                    dependencyObjects.Add(RootDir);
                }
                else if(param.Name == "siteFolder")
                {
                    dependencyObjects.Add(RoutingUrl.SitePath);
                }
                else if (param.Name == "repository")
                {
                    dependencyObjects.Add(Activator.CreateInstance(param.ParameterType, RoutingUrl.SitePath));
                }
                else
                {
                    dependencyObjects.Add(Activator.CreateInstance(param.ParameterType));
                }
            }
            return dependencyObjects.ToArray(); 
        }

        public static T GetObjByType<T>()
        {
            return (T)services[typeof(T)];
        }

    }
}
