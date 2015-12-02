module Myteletouch {
    "use strict";

    export module Model {
        export class CountryText extends BaseModel {
            public CountryId: number;
            public Locale: string;
            public Name: string;
        }
    }
}