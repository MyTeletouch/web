using Resources;
using RouteConfigEntities;
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
        const string BASE_URL = "{culture}/";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes = RegisterAngularRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: BASE_URL + "{controller}/{action}/{id}",
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
            List<AngularMapRouteEntity> angularRoutes = GetAngularApplicationRoutes();

            foreach (AngularMapRouteEntity angularMapRouteEntity in angularRoutes)
            {
                if (angularMapRouteEntity.MapRouteEntity == null)
                {
                    throw new Exception(string.Format("MapRouteEntity can't be blank."));
                }

                routes.MapRoute(
                    name: angularMapRouteEntity.RouteName,
                    url: angularMapRouteEntity.RouteURL,
                    defaults: new
                    {
                        culture = CultureHelper.GetDefaultCulture(),
                        controller = angularMapRouteEntity.MapRouteEntity.Controller,
                        action = angularMapRouteEntity.MapRouteEntity.ActionMethod
                    }
                );
            }

            return routes;
        }

        private static List<AngularMapRouteEntity> GetAngularApplicationRoutes()
        {
            List<AngularMapRouteEntity> routes = new List<AngularMapRouteEntity>();

            // Form: UserShippingAddress
            var userShippingAddress = 
                new AngularMapRouteEntity("AngularUserShippingAddress", BASE_URL + "/angular/usershippingaddress");
            userShippingAddress.MapRouteEntity = new MapRouteEntity("AngularLoader", "ApplicationUserShippingAddressPageCtrl");
            routes.Add(userShippingAddress);

            return routes;
        }
    }
}
