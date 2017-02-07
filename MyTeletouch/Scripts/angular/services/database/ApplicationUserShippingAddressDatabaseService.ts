/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../../entities/dom/formelements/form/form.ts" />
/// <reference path="../../entities/dom/formelements/submitbutton/submitbutton.ts" />
/// <reference path="../../models/applicationuser.ts" />
/// <reference path="../../models/applicationusershippingaddress.ts" />
/// <reference path="../../models/viewmodels/productviewmodels/producttotalcostitem.ts" />
/// <reference path="../../models/viewmodels/productviewmodels/productviewmodelitem.ts" />
/// <reference path="../../entities/dom/formelements/selectbox/selectoption.ts" />

module Myteletouch {
    "use strict";

    export module Service {
        export module Database {

            type ApplicationUserShippingAddress = Myteletouch.Model.ApplicationUserShippingAddress;
            type ApplicationUser = Myteletouch.Model.ApplicationUser;
            type ProductTotalCostItem = Myteletouch.Model.ViewModel.ProductViewModel.ProductTotalCostItem;
            type ProductViewModelItem = Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem;
            type SelectOption = Myteletouch.Entity.DOM.FormElement.SelectBox.SelectOption;

            export interface IApplicationUserShippingAddressDatabaseService extends Myteletouch.Service.Database.IDatabaseService {
                form: Myteletouch.Entity.DOM.FormElement.Form.Form;
                submitButton: Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton;

                // View Models
                ProductTotalCostItem: Myteletouch.Model.ViewModel.ProductViewModel.ProductTotalCostItem;
                ProductViewModelItem: Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem;

                // Models
                UserShippingAddress: ApplicationUserShippingAddress;
                User: ApplicationUser;

                // Select Box
                Country: SelectOption;
            }

            /**
             * ApplicationUserShippingAddressDatabaseService should to operate with form information for adding a user shipping address in database.
             */
            class ApplicationUserShippingAddressDatabaseService implements IApplicationUserShippingAddressDatabaseService {

                static $inject = ['$resource', '$rootScope'];

                private _form: Myteletouch.Entity.DOM.FormElement.Form.Form;
                private _submitButton: Myteletouch.Entity.DOM.FormElement.SubmitButton.SubmitButton;

                // View Models
                private _ProductTotalCostItem: Myteletouch.Model.ViewModel.ProductViewModel.ProductTotalCostItem;
                private _ProductViewModelItem: Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem;

                // Models
                private _User: ApplicationUser;
                private _UserShippingAddress: ApplicationUserShippingAddress;

                // Select Box
                private _Country: SelectOption;

                constructor(private $resource, private $rootScope) {
                    this._User = new Myteletouch.Model.ApplicationUser();
                    this._UserShippingAddress = new Myteletouch.Model.ApplicationUserShippingAddress();

                    this._Country = new Myteletouch.Entity.DOM.FormElement.SelectBox.SelectOption();
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

                get ProductTotalCostItem(): Myteletouch.Model.ViewModel.ProductViewModel.ProductTotalCostItem {
                    return this._ProductTotalCostItem;
                }

                get ProductViewModelItem(): Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem {
                    return this._ProductViewModelItem;
                }

                set ProductViewModelItem(newValue: Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem) {
                    this._ProductViewModelItem = newValue;
                    this._ProductTotalCostItem = new Myteletouch.Model.ViewModel.ProductViewModel.ProductTotalCostItem(this.ProductViewModelItem);
                }

                get User(): Myteletouch.Model.ApplicationUser {
                    return this._User;
                }

                set User(newValue: Myteletouch.Model.ApplicationUser) {
                    this._User = newValue;
                }

                get UserShippingAddress(): Myteletouch.Model.ApplicationUserShippingAddress {
                    return this._UserShippingAddress;
                }

                set UserShippingAddress(newValue: Myteletouch.Model.ApplicationUserShippingAddress) {
                    this._UserShippingAddress = newValue;
                } 

                get Country(): Myteletouch.Entity.DOM.FormElement.SelectBox.SelectOption {
                    return this._Country;
                }

                set Country(newValue: Myteletouch.Entity.DOM.FormElement.SelectBox.SelectOption) {
                    this._Country = newValue;
                }

                /**
                 * Get information for ApplicationUser and ApplicationUserShippingAddress 
                 * and try to save information to database.
                 */
                saveRecordToDabase() {
                    console.log(this.Country);

                    // Update Information for country
                    this.UserShippingAddress.CountryId = this.Country.Id;

                    console.log(this.User, this.UserShippingAddress, this.Country);
                    

                    this.User.PhoneNumber = this.UserShippingAddress.PhoneNumber;
                    // Validate user input data
                    const userInformationIsValid = (!this.User.requiredFieldsAreEmpty());
                    const userShippingInformationIsValid = (!this.UserShippingAddress.requiredFieldsAreEmpty());

                    if (userInformationIsValid && userShippingInformationIsValid) {
                        console.log(this.ProductTotalCostItem);
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

