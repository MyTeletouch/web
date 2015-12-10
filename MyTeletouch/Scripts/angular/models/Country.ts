/// <reference path="basemodel.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class Country extends BaseModel  {
            private _CountryCode: string;

            constructor() {
                super();

                this._CountryCode = null;
            }

            get Id(): number {
                return this.Id;
            }

            get CountryCode(): string {
                return this._CountryCode;
            }

            set CountryCode(newValue: string) {
                this._CountryCode = newValue;
            }
        }
    }
}