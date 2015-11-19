using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteConfigEntities
{
    public class MapRouteEntity
    {
        public string Controller { get; set; }
        public string ActionMethod { get; set; }

        public MapRouteEntity(string Controller, string ActionMethod)
        {
            this.Controller = Controller;
            this.ActionMethod = ActionMethod;
        }
    }
}
