module Myteletouch {
    "use strict";

    export module Configurations {
        export class RouteLink {
            public key: string;
            public location: string;

            constructor(key: string, location: string) {
                this.key = key;
                this.location = location;
            }
        }
    }
}