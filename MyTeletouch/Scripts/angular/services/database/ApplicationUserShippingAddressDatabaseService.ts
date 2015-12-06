/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../../entities/dom/formelements/form/form.ts" />
/// <reference path="../../entities/dom/formelements/submitbutton/submitbutton.ts" />
/// <reference path="../../models/applicationuser.ts" />
/// <reference path="../../models/applicationusershippingaddress.ts" />

module Myteletouch {
    "use strict";

    export module Service {
        export module Database {

            type ApplicationUserShippingAddress = Myteletouch.Model.ApplicationUserShippingAddress;
            type ApplicationUser = Myteletouch.Model.ApplicationUser;

            export interface IApplicationUserShippingAddressDatabaseService extends Myteletouch.Service.Database.IDatabaseService {
                form: Myteletouch.Entity.DOM.FormElement.Form.Form;
                submitButton: Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton;
                userShippingAddress: ApplicationUserShippingAddress;
                user: ApplicationUser;
            }

            /**
             * ApplicationUserShippingAddressDatabaseService should to operate with form information for adding a user shipping address in database.
             */
            class ApplicationUserShippingAddressDatabaseService implements IApplicationUserShippingAddressDatabaseService {

                static $inject = ['$resource', '$rootScope'];

                private _form: Myteletouch.Entity.DOM.FormElement.Form.Form;
                private _submitButton: Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton;
                private _user: ApplicationUser;
                private _userShippingAddress: ApplicationUserShippingAddress;

                constructor(private $resource, private $rootScope) {
                    this._userShippingAddress = new Myteletouch.Model.ApplicationUserShippingAddress();
                    this._user = new Myteletouch.Model.ApplicationUser();
                }

                get form(): Myteletouch.Entity.DOM.FormElement.Form.Form {
                    return this._form;
                }

                set form(newValue: Myteletouch.Entity.DOM.FormElement.Form.Form) {
                    this._form = newValue;
                }

                get submitButton(): Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton {
                    return this._submitButton;
                }

                set submitButton(newValue: Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton) {
                    this._submitButton = newValue;
                }

                get userShippingAddress(): Myteletouch.Model.ApplicationUserShippingAddress {
                    return this._userShippingAddress;
                }

                set userShippingAddress(newValue: Myteletouch.Model.ApplicationUserShippingAddress) {
                    this._userShippingAddress = newValue;
                } 

                get user(): Myteletouch.Model.ApplicationUser {
                    return this._user;
                }

                set user(newValue: Myteletouch.Model.ApplicationUser) {
                    this._user = newValue;
                }

                /**
                 * Get information for ApplicationUser and ApplicationUserShippingAddress 
                 * and try to save information to database.
                 */
                saveRecordToDabase() {
                    console.log(this.user, this.userShippingAddress);
                    this.user.PhoneNumber = this.userShippingAddress.PhoneNumber;
                    const userInformationIsValid = (!this.user.requiredFieldsAreEmpty());
                    const userShippingInformationIsValid = (!this.userShippingAddress.requiredFieldsAreEmpty());

                    if (userInformationIsValid && userShippingInformationIsValid) {

                    } else {
                        alert("Please fill in all mandatory fields.");
                        this.form.changeToErrorState();
                    }
                }
            }

            angular
                .module("Myteletouch")
                .service("ApplicationUserShippingAddressDatabaseService", ApplicationUserShippingAddressDatabaseService);
        }
    }
}

