using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyTeletouch
{
    public static class WebApiConfig
    {
        const string MAIN_TEMPLATE = "api/v1/{locale}/";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetProductByInternalCode",
                routeTemplate: CreateRouteTemplate("products/byinternalcode/{internalCode}"),
                defaults: new
                {
                    controller = "ProductWebAPI",
                    action = "GetProductByInternalCode"
                }
            );

            config.Routes.MapHttpRoute(
                name: "GetCountryList",
                routeTemplate: CreateRouteTemplate("countries/countrylist"),
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

        /// <summary>
        /// Make concatenation between: WebApiConfig.MAIN_TEMPLATE and routeName
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public static string CreateRouteTemplate(string routeName)
        {
            return WebApiConfig.MAIN_TEMPLATE + routeName;
        }
    }
}
