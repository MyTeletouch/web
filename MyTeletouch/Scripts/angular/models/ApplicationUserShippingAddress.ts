module Myteletouch {
    "use strict";

    export module Model {
        export class ApplicationUserShippingAddress extends BaseModel {
            public UserId: string;
            public CountryId: number;
            public PrimaryAddress: string;
            public SecondaryAddress: string;
            public City: string;
            public State: string;
            public ZIP: string;
            public PhoneNumber: string;
        }
    }
}