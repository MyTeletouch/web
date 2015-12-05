module Myteletouch {
    "use strict";

    export module Model {
        export class ApplicationUserShippingAddress extends BaseModel {
            private _UserId: string;
            private _CountryId: number;
            private _PrimaryAddress: string;
            private _SecondaryAddress: string;
            private _City: string;
            private _State: string;
            private _ZIP: string;
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
        }
    }
}