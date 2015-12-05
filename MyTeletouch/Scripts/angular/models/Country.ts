module Myteletouch {
    "use strict";

    export module Model {
        export class Country extends BaseModel  {
            public _CountryCode: string;

            constructor() {
                super();

                this._CountryCode = null;
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