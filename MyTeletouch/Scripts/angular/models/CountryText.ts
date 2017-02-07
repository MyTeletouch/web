/// <reference path="basemodel.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class CountryText extends BaseModel {
            private _CountryId: number;
            private _Locale: string;
            private _Name: string;

            constructor() {
                super();

                this._CountryId = null;
                this._Locale = null;
                this._Name = null;
            }

            get Id(): number {
                return this.Id;
            }

            get CountryId(): number {
                return this._CountryId;
            }

            set CountryId(newValue: number) {
                this._CountryId = newValue;
            }

            get Locale(): string {
                return this._Locale;
            }

            set Locale(newValue: string) {
                this._Locale = newValue;
            }

            get Name(): string {
                return this._Name;
            }

            set Name(newValue: string) {
                this._Name = newValue;
            }
        }
    }
}