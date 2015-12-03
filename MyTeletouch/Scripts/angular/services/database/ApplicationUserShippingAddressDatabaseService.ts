/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../../entities/formelement/state/submitbutton.ts" />

module Myteletouch {
    "use strict";

    export module Service {
        export module Database {
            export interface IApplicationUserShippingAddressDatabaseService extends Myteletouch.Service.Database.IDatabaseService {
                formControlStyle: string;
                submitButton: Myteletouch.Entity.FormElement.SubmitButton;
            }

            /**
             * ApplicationUserShippingAddressDatabaseService should to operate with form information for adding a user shipping address in database.
             */
            class ApplicationUserShippingAddressDatabaseService implements IApplicationUserShippingAddressDatabaseService {

                static $inject = ['$resource', '$rootScope'];

                private _formControlStyle: string;
                private _submitButton: Myteletouch.Entity.FormElement.SubmitButton;

                constructor(private $resource, private $rootScope) {
                    
                }

                get formControlStyle(): string {
                    return this._formControlStyle;
                }

                set formControlStyle(newValue: string) {
                    this._formControlStyle = newValue;
                }

                get submitButton(): Myteletouch.Entity.FormElement.SubmitButton {
                    return this._submitButton;
                }

                set submitButton(newValue: Myteletouch.Entity.FormElement.SubmitButton) {
                    this._submitButton = newValue;
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

