/// <reference path="basemodel.ts" />
/// <reference path="../types/basictypes/applicationstring.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class ApplicationUserShippingAddress extends BaseModel {
            // Optional field. 
            // Note field is optional only for front end.
            private _UserId: string;

            // Required field
            private _CountryId: number;

            // Required field
            private _PrimaryAddress: string;

            // Optional field
            private _SecondaryAddress: string;

            // Optional field
            private _City: string;

            // Required field
            private _State: string;

            // Required field
            private _ZIP: string;

            // Required field
            private _PhoneNumber: string;

            constructor() {
                super();

                this._UserId = null;
                this._CountryId = null;
                this._PrimaryAddress = null;
                this._SecondaryAddress = null;
                this._City = null;
                this._State = null;
                this._ZIP = null;
                this._PhoneNumber = null;
            }

            get Id(): number {
                return this.Id;
            }

            get UserId(): string {
                return this._UserId;
            }

            set UserId(newValue: string) {
                this._UserId = newValue;
            }

            get CountryId(): number {
                return this._CountryId;
            }

            set CountryId(newValue: number) {
                this._CountryId = newValue;
            }

            get PrimaryAddress(): string {
                return this._PrimaryAddress;
            }

            set PrimaryAddress(newValue: string) {
                this._PrimaryAddress = newValue;
            }

            get SecondaryAddress(): string {
                return this._SecondaryAddress;
            }

            set SecondaryAddress(newValue: string) {
                this._SecondaryAddress = newValue;
            }

            get City(): string {
                return this._City;
            }

            set City(newValue: string) {
                this._City = newValue;
            }

            get State(): string {
                return this._State;
            }

            set State(newValue: string) {
                this._State = newValue;
            }

            get ZIP(): string {
                return this._ZIP;
            }

            set ZIP(newValue: string) {
                this._ZIP = newValue;
            }


            get PhoneNumber(): string {
                return this._PhoneNumber;
            }

            set PhoneNumber(newValue: string) {
                this._PhoneNumber = newValue;
            }

            /**
             * If you have at least one empty field, we should to return true.
             * Require fields are:
             * 1. CountryId
             * 2. PrimaryAddress
             * 3. City
             * 4. State
             * 5. ZIP
             * 6. PhoneNumber
             */
            requiredFieldsAreEmpty(): boolean {
                const countryIdIsEmpty: boolean = (this.CountryId === null);
                const primaryAddressIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.PrimaryAddress);
                const cityIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.City);
                const stateIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.State);
                const zipIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.ZIP);
                const phoneNumberIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.PhoneNumber);

                if (countryIdIsEmpty || primaryAddressIsEmpty || cityIsEmpty || stateIsEmpty || zipIsEmpty || phoneNumberIsEmpty) {
                    // we have at least one empty field.
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}