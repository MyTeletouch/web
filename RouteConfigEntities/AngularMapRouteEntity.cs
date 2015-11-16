using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteConfigEntities
{
    public class AngularMapRouteEntity
    {
        public string RouteName { get; set; }
        public string RouteURL { get; set; }
        public MapRouteEntity MapRouteEntity { get; set; }

        public AngularMapRouteEntity(string RouteName, string RouteURL)
        {
            this.RouteName = RouteName;
            this.RouteURL = RouteURL;
        }
    }
}
