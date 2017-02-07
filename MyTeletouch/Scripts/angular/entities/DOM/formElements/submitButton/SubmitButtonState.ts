module Myteletouch {
    "use strict";

    export module Entity {
        export module DOM {
            export module FormElement {
                export module SubmitButton {
                    export module Enum {

                        /**
                         * Every submit button have three states
                         * Normal State - before sending information to database
                         * Loading State - we waiting response from remote server.
                         * Error State - if you something is not correct and our information can't be saved in database.
                         * Note: f you information is correct from Loading state, we should to back to normal state.
                         */
                        export enum State {
                            Normal,
                            Loading,
                            Error
                        };
                    }
                }
            }
        }
    }
}