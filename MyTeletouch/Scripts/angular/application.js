// http://www.developerhandbook.com/typescript/writing-angularjs-1-x-with-typescript/

(function () {
    'use strict';

    angular.module('Myteletouch', ['ngResource', 'ngRoute'])
        .config(configuration)

        .directive('myMaxlength', function () {
            return {
                require: 'ngModel',
                link: function (scope, element, attrs, ngModelCtrl) {
                    var maxlength = Number(attrs.myMaxlength);
                    function fromUser(text) {
                        if (text.length > maxlength) {
                            var transformedInput = text.substring(0, maxlength);
                            ngModelCtrl.$setViewValue(transformedInput);
                            ngModelCtrl.$render();
                            return transformedInput;
                        }
                        return text;
                    }
                    ngModelCtrl.$parsers.push(fromUser);
                }
            };
        })

        // Source and Idea: http://blog.revolunet.com/blog/2014/02/14/angularjs-services-inheritance/
        .factory('BaseFactoryMessage', ['$resource', '$rootScope', function ($resource, $rootScope) {
            var messages = []; // Pointer to $scope.clientMessages
            var formControlStyle = '';
            var buttonTextMessage = '';
            var dbReference = '';
            var message = null;

            var BaseFactoryMessage = function (URI, messages, formControlStyle, buttonTextMessage) {
                this.messages = messages;
                this.formControlStyle = formControlStyle;
                this.buttonTextMessage = buttonTextMessage;
                this.dbReference = $resource(URI, { id: '@id.clean' });
                this.message = new this.dbReference({});
            };

            BaseFactoryMessage.prototype.setMessages = function (messages) {
                this.messages = messages;
            };

            BaseFactoryMessage.prototype.saveRecordToDabase = function () {
                var defaultMessage = this.buttonTextMessage;
                this.buttonTextMessage = 'Saving';
                var _this = this;

                this.message.$save(function (responseMessage) {
                    _this.formControlStyle = 'has-success';
                    _this.message = new _this.dbReference({});
                    _this.buttonTextMessage = defaultMessage;

                    console.log(responseMessage);

                    if (_this.messages instanceof Array) {
                        _this.messages.unshift(responseMessage);
                    }
                }, function (error) {
                    _this.formControlStyle = 'has-error';
                    _this.buttonTextMessage = defaultMessage;
                });
            };

            return BaseFactoryMessage;
        }])

        .factory('ClientMessage', ['BaseFactoryMessage', function (BaseFactoryMessage) {
            // create our new custom object that reuse the original object constructor
            var ClientMessage = function () {
                BaseFactoryMessage.apply(this, arguments);
            };

            // reuse the original object prototype
            BaseFactoryMessage.prototype = new BaseFactoryMessage();

            ClientMessage.prototype.save = function () {
                BaseFactoryMessage.prototype.saveRecordToDabase.call(this);
            };

            ClientMessage.prototype.setMessages = function (messages) {
                BaseFactoryMessage.prototype.setMessages.call(this, messages);
            };

            return ClientMessage;
        }])

        .factory('MongoDbMessage', ['BaseFactoryMessage', function (BaseFactoryMessage) {
            // create our new custom object that reuse the original object constructor
            var MongoDbMessage = function () {
                BaseFactoryMessage.apply(this, arguments);
            };

            // reuse the original object prototype
            BaseFactoryMessage.prototype = new BaseFactoryMessage();

            MongoDbMessage.prototype.save = function () {
                BaseFactoryMessage.prototype.saveRecordToDabase.call(this);
            };

            MongoDbMessage.prototype.setMessages = function (messages) {
                BaseFactoryMessage.prototype.setMessages.call(this, messages);
            };

            return MongoDbMessage;
        }])

        /**
         * @ngdoc overview
         * @name TwitterBackup:controller:TwitterBackupCtrl
         * @description
         * 
         * Main controller of the application.
         */
        .controller('ApplicationUserShippingAddressPageCtrl', ['$scope', '$http', '$resource',
            function ($scope, $http, $resource) {

                

            }]); // END ApplicationUserShippingAddressPageCtrl

    // Load configurations
    configuration.$inject = ['$routeProvider', '$locationProvider'];

    /**
    * @ngdoc overview
    * @name Angularjs::routes configuration
    * @description
    * @param $routeProvider Used for configuring routes.
    * @param $locationProvider Use the $locationProvider to configure how the
    */
    function configuration($routeProvider, $locationProvider) {
        // Configure the routes
        $routeProvider

            // Load information for shipping address
            .when('/:culture/angular/usershippingaddress', {
                controller: 'ApplicationUserShippingAddressPageCtrl',
                templateUrl: '/AngularTemplates/usershippingaddress.html'
            });

        // use the HTML5 History API
        $locationProvider.html5Mode(true);
    };

    /**
     * Uppercase keys object keys.
     */
    Object.withCapitalizeKeys = function withCapitalizeKeys(object) {
        // this solution ignores inherited properties
        var newObject = {}, capitalizeKey = null;
        for (var iterator in object) {
            if (typeof iterator === 'string') {
                capitalizeKey = capitalizeFirstLetter(iterator);
                newObject[capitalizeKey] = object[iterator];
            }
        }

        return newObject;
    };

    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    };
})();
