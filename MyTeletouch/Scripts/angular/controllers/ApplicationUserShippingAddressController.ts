/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../configurations/routes.ts" />
/// <reference path="../models/viewmodels/countryviewmodels/countrylistitem.ts" />
/// <reference path="../models/viewmodels/productviewmodels/productviewmodelitem.ts" />
/// <reference path="../services/database/applicationusershippingaddressdatabaseservice.ts" />
/// <reference path="../entities/dom/formelements/form/form.ts" />
/// <reference path="../entities/dom/formelements/submitbutton/submitbutton.ts" />


module Myteletouch {
    "use strict";

    export module Controller {
        
        // http://blogs.msdn.com/b/typescript/archive/2014/11/18/what-s-new-in-the-typescript-type-system.aspx
        type CountryListItem = Myteletouch.Model.ViewModel.CountryViewModel.CountryListItem;
        type IApplicationUserShippingAddressDatabaseService = Myteletouch.Service.Database.IApplicationUserShippingAddressDatabaseService;
        type Form = Myteletouch.Entity.DOM.FormElement.Form.Form;
        type SubmitButton = Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton;
        type ProductViewModelItem = Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem;
        type RoutingTable = Myteletouch.Configurations.RoutingTable;

        /**
         * @ngdoc overview
         * @name Myteletouch:controller:ApplicationUserShippingAddressController
         * @description
         * 
         * Controller loading shipping form and save information to database.
         */
        class ApplicationUserShippingAddressController {
            static $inject = ['$scope', '$http', '$resource', 'ApplicationUserShippingAddressDatabaseService'];

            private _LocalApplicationUserShippingAddressDatabaseService: Myteletouch.Service.Database.IApplicationUserShippingAddressDatabaseService;

            constructor(
                private $scope,
                private $http: ng.IHttpService,
                private $resource,
                private ApplicationUserShippingAddressDatabaseService: IApplicationUserShippingAddressDatabaseService,
                private locale: string) {

                this.locale = 'en';

                // ApplicationUserShippingAddressDatabaseService
                this._LocalApplicationUserShippingAddressDatabaseService = ApplicationUserShippingAddressDatabaseService;
                this.initializeApplicationUserShippingAddressDatabaseService($scope);

                this.getCountryList($scope, $http);
                this.getProductByInternalCode($scope, $http);
            }

            get LocalApplicationUserShippingAddressDatabaseService(): Myteletouch.Service.Database.IApplicationUserShippingAddressDatabaseService {
                return this._LocalApplicationUserShippingAddressDatabaseService;
            }

            set LocalApplicationUserShippingAddressDatabaseService(newValue: Myteletouch.Service.Database.IApplicationUserShippingAddressDatabaseService) {
                this._LocalApplicationUserShippingAddressDatabaseService = newValue;
            }

            /**
             * Generate information for form control and submit button.
             * For form controll we generate classes for diffirent states.
             * For submit button we generate labels for different states.
             * 
             * Finaly we generate a pointer reference between IApplicationUserShippingAddressDatabaseService and $scope.
             * 
             * @property $scope 
             */
            private initializeApplicationUserShippingAddressDatabaseService($scope): void {
                
                // Add information for form
                const tempForm: Form = new Myteletouch.Entity.DOM.FormElement.Form.Form(
                    "",
                    "has-success",
                    "has-error"
                );
                this.LocalApplicationUserShippingAddressDatabaseService.form = tempForm;
                
                // Add information for submit button
                const tempButton: SubmitButton = new Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton(
                    "Please add your shipping details",
                    "Saving",
                    "Invalid data"
                );
                this.LocalApplicationUserShippingAddressDatabaseService.submitButton = tempButton;

                $scope.LocalApplicationUserShippingAddressDatabaseService = this.LocalApplicationUserShippingAddressDatabaseService;
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
                const countryListBackendURI: string = Myteletouch.Configurations.RoutingTable.countryList(this.locale);

                $scope.countries = new Array<CountryListItem>();
                $http.get(countryListBackendURI).success(function (data: Array<CountryListItem>, status, headers, config) {
                    $scope.countries = data;
                }).error(function (data, status, headers, config) {
                    alert("Please try again later.");
                });
            }

            /**
             * @ngdoc function
             * @name Myteletouch:controller:ApplicationUserShippingAddressController
             * @method
             * @description
             * Angularjs send request to backend and if you everything is correct, application should to receive product information
             * @property $http service is a core Angular service that facilitates communication with the remote HTTP servers via the browser's XMLHttpRequest object or via JSONP.  
             */
            private getProductByInternalCode($scope, $http: ng.IHttpService): void {
                const internalCode: string = "MyTeletouch";
                const backendURI: string =
                    Myteletouch.Configurations.RoutingTable.productInfoByInternalCode(internalCode, this.locale);
                console.log(backendURI);
                
                const _this = this;
                $http.get(backendURI).success(function (productViewModelItem: ProductViewModelItem, status, headers, config) {
                    _this.LocalApplicationUserShippingAddressDatabaseService.ProductViewModelItem = productViewModelItem;
                    console.log(_this.LocalApplicationUserShippingAddressDatabaseService.ProductTotalCostItem.Quantity);
                }).error(function (data, status, headers, config) {
                    alert("Product is unreachable");
                });
            }
        }

        angular
            .module("Myteletouch")
            .controller("ApplicationUserShippingAddressController", ApplicationUserShippingAddressController);
    }
}
