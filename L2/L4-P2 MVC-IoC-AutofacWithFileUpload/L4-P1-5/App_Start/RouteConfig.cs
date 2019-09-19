using System.Web.Mvc;
using System.Web.Routing;

namespace L4_P1_5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           



            routes.MapRoute(
                name: "DefaultHome",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{*values}",
               defaults: new { controller = "Home", action = "Index" }
           );
        }
    }
}
