using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobLineAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "user", action = "get", id = UrlParameter.Optional }
            ); //Route: /Special/12

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
