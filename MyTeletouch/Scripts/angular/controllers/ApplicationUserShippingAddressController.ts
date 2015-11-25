/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../configurations/routes.ts" />
/// <reference path="../models/viewmodels/countryviewmodels/countrylistitem.ts" />

// http://blogs.msdn.com/b/typescript/archive/2014/11/18/what-s-new-in-the-typescript-type-system.aspx
type CountryListItem = Myteletouch.Model.ViewModel.CountryViewModel.CountryListItem;

module Myteletouch {
    "use strict";

    class ApplicationUserShippingAddressController {
        static $inject = ['$scope', '$http', '$resource'];

        constructor($scope, $http, $resource) {
            const countryListBackendURI: string = 'api/v1/en/countries/countrylist';

            $scope.countries = new Array<CountryListItem>();
            $http.get(countryListBackendURI).success(function (data: Array<CountryListItem>, status, headers, config) {
                $scope.countries = data;
            }).error(function (data, status, headers, config) {
                alert("Please try again later.");
            });
        }
    }

    angular
        .module("Myteletouch")
        .controller("ApplicationUserShippingAddressController", ApplicationUserShippingAddressController);
}
