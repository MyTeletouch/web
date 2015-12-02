/// <reference path="../../../typings/angularjs/angular.d.ts" />

module Myteletouch {
    "use strict";

    export module Service {
        export module Database {
            export interface IApplicationUserShippingAddressDatabaseService extends Myteletouch.Service.Database.IDatabaseService {
                formControlStyle: string;
                buttonTextMessage: string;
            }

            /**
             * ApplicationUserShippingAddressDatabaseService should to operate with form information for adding a user shipping address in database.
             */
            class ApplicationUserShippingAddressDatabaseService implements IApplicationUserShippingAddressDatabaseService {

                static $inject = ['$resource', '$rootScope'];

                private _formControlStyle: string;
                private _buttonTextMessage: string;

                constructor(private $resource, private $rootScope) {
                    
                }

                get formControlStyle(): string {
                    return this._formControlStyle;
                }

                set formControlStyle(newValue: string) {
                    this._formControlStyle = newValue;
                }

                get buttonTextMessage(): string {
                    return this._buttonTextMessage;
                }

                set buttonTextMessage(newValue: string) {
                    this._buttonTextMessage = newValue;
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

