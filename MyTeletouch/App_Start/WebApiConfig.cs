using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyTeletouch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetCountryList",
                routeTemplate: "api/v1/{locale}/countries/countrylist",
                defaults: new
                {
                    controller = "CountryWebAPI",
                    action = "GetCountryList"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
