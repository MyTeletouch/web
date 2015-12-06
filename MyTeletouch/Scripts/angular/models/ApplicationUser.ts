/// <reference path="basemodel.ts" />
/// <reference path="../types/basictypes/applicationstring.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class ApplicationUser extends BaseModel {
            // Required field
            private _Email: string;

            // Required field
            private _Username: string;

            // Required field
            private _PhoneNumber: string;

            constructor() {
                super();

                this._Email = null;
                this._Username = null;
                this._PhoneNumber = null;
            }

            get Id(): string {
                return this.Id;
            }

            get Email(): string {
                return this._Email;
            }

            set Email(newValue: string) {
                this._Email = newValue;
                // Temporary username will be equal to email
                this._Username = newValue;
            }

            get Username(): string {
                return this._Username;
            }

            set Username(newValue: string) {
                this._Username = newValue;
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
             * 1. Email
             * 2. Username
             * 3. Phone number
             */
            requiredFieldsAreEmpty(): boolean {
                const emailIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.Email);
                const usernameIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.Username);
                const phoneNumberIsEmpty: boolean = Type.BaseType.ApplicationString.isNullOrEmpty(this.PhoneNumber);

                if (emailIsEmpty || usernameIsEmpty || phoneNumberIsEmpty) {
                    // we have at least one empty field.
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}