using System.Web.Mvc;
using System.Web.Routing;

namespace ATU.Web.Interface
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "TwoParams",
            //    url: "{controller}/{action}/{param1}/{param2}",
            //    defaults: new { controller = "Home", action = "Index", param1 = "", param2 = "" });
        }
    }
}