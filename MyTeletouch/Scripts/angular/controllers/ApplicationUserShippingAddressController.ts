/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../configurations/routes.ts" />
/// <reference path="../models/viewmodels/countryviewmodels/countrylistitem.ts" />
/// <reference path="../services/database/applicationusershippingaddressdatabaseservice.ts" />

// http://blogs.msdn.com/b/typescript/archive/2014/11/18/what-s-new-in-the-typescript-type-system.aspx
type CountryListItem = Myteletouch.Model.ViewModel.CountryViewModel.CountryListItem;
type IApplicationUserShippingAddressDatabaseService = Myteletouch.Service.Database.IApplicationUserShippingAddressDatabaseService;

module Myteletouch {
    "use strict";

    export module Controller {

        /**
         * @ngdoc overview
         * @name Myteletouch:controller:ApplicationUserShippingAddressController
         * @description
         * 
         * Controller loading shipping form and save information to database.
         */
        class ApplicationUserShippingAddressController {
            static $inject = ['$scope', '$http', '$resource', 'ApplicationUserShippingAddressDatabaseService'];

            constructor($scope, $http: ng.IHttpService, $resource, ApplicationUserShippingAddressDatabaseService: IApplicationUserShippingAddressDatabaseService) {
                // $scope.userShippingAddress = new ApplicationUserShippingAddressFactory();
                console.log(ApplicationUserShippingAddressDatabaseService);

                this.getCountryList($scope, $http);
            }

            /**
             * @ngdoc function
             * @name Myteletouch:controller:ApplicationUserShippingAddressController
             * @method 
             * @description
             * Angularjs send request to backend and if you everything is fine, we should to have a new Array<CountryListItem> with 250+ countries
             * @property $scope
             * @property $http service is a core Angular service that facilitates communication with the remote HTTP servers via the browser's XMLHttpRequest object or via JSONP.  
             */
            private getCountryList($scope, $http: ng.IHttpService): void {
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
}
