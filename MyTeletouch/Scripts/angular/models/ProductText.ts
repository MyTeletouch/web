/// <reference path="basemodel.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class ProductText extends BaseModel {
            private _ProductId: number;
            private _Locale: string;
            private _Name: string;
            private _Slogon: string;
            private _Description: string;

            constructor() {
                super();

                this._ProductId = null;
                this._Locale = null;
                this._Name = null;
                this._Slogon = null;
                this._Description = null;
            }

            get Id(): number {
                return this.Id;
            }

            get ProductId(): number {
                return this._ProductId;
            }

            set ProductId(newValue: number) {
                this._ProductId = newValue;
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

            get Slogon(): string {
                return this._Slogon;
            }

            set Slogon(newValue: string) {
                this._Slogon = newValue;
            }

            get Description(): string {
                return this._Description;
            }

            set Description(newValue: string) {
                this._Description = newValue;
            }
        }
    }
}