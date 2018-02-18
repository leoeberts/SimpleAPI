using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleAPI
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}",
                new {controller = "Years"}
            );
        }
    }
}