using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace SimpleAPI
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(configuration => WebApiConfig.Register(configuration));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}