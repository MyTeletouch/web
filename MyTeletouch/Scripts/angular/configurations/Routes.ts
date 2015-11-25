/// <reference path="routelink.ts" />

module Myteletouch {
    export module Configurations {
        export class Route {
            // Get countries
            static Country: RouteLink = new RouteLink("countrylist", 'countries/countrylist');
        }
    }
}