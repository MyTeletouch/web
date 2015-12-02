/// <reference path="../../../typings/angularjs/angular.d.ts" />

module Myteletouch {
    "use strict";

    export module Service {
        export module Database {
            export interface IApplicationUserShippingAddressDatabaseService extends Myteletouch.Service.Database.IDatabaseService {
            }

            class ApplicationUserShippingAddressDatabaseService implements IApplicationUserShippingAddressDatabaseService {

                static $inject = ['$resource', '$rootScope'];

                constructor(private $resource, private $rootScope) {
                    
                }

                saveRecordToDabase() {
                    return;
                }
            }

            angular
                .module("Myteletouch")
                .service("ApplicationUserShippingAddressDatabaseService", ApplicationUserShippingAddressDatabaseService);
        }
    }
}

