/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />

module Myteletouch {
    "use strict";

    class ApplicationUserShippingAddressController {
        static $inject = ['$scope', '$http', '$resource'];

        constructor() {
            
        }
    }

    angular
        .module("Myteletouch")
        .controller("ApplicationUserShippingAddressController", ApplicationUserShippingAddressController);
}
