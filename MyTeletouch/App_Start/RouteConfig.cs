using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyTeletouch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes = RouteConfig.RegisterAngularRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        /// <summary>
        /// Add Support for Angularjs routes.
        /// We need this support, because if you user press reload button, ASP.Net need to know how to proceed.
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        private static RouteCollection RegisterAngularRoutes(RouteCollection routes)
        {
            Dictionary<string, string> angularRoutes = new Dictionary<string, string>();
            angularRoutes["AngularHomePage"] = "angular/homepage";

            foreach (KeyValuePair<string, string> entry in angularRoutes)
            {
                routes.MapRoute(
                    name: entry.Key,
                    url: entry.Value,
                    defaults: new
                    {
                        controller = "Home",
                        action = "AngularHomePage"
                    }
                );
            }

            return routes;
        }
    }
}
