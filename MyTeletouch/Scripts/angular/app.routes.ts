/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/angularjs/angular-route.d.ts" />

module Myteletouch {
    "use strict";

    angular.module('Myteletouch')
        .config(configurations);

    // Load configurations
    configurations.$inject = ['$routeProvider', '$locationProvider'];

    /**
    * @ngdoc overview
    * @name Angularjs::routes configurations
    * @description
    * @param $routeProvider Used for configuring routes.
    * @param $locationProvider Use the $locationProvider to configure how the
    */
    function configurations($routeProvider: ng.route.IRouteProvider, $locationProvider: ng.ILocationProvider) {
        var viewFolder = '/Scripts/angular/views';
        
        // Configure the routes
        $routeProvider

        // Load information for shipping address
            .when('/:culture/angular/usershippingaddress', {
                controller: 'ApplicationUserShippingAddressController',
                templateUrl: viewFolder + '/usershippingaddress/form.html'
            })
            .otherwise({
                redirectTo: "/"
            });

        // use the HTML5 History API
        $locationProvider.html5Mode(true);
    };
}