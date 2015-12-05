module Myteletouch {
    "use strict";

    export module Entity {
        export module DOM {
            export module FormElement {
                export module Form {
                    export module Enum {

                        /**
                         * Every form have three states
                         * Normal State: - before sending information to database
                         * Success State: - our information is saved successfully in our database.
                         * Error State - if you something is not correct and our information can't be saved in database.
                         * Note: f you information is correct from Loading state, we should to back to normal state.
                         */
                        export enum State {
                            Normal,
                            Success,
                            Error
                        };
                    }
                }
            }
        }
    }
}