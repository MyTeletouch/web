module Myteletouch {
    "use strict";

    export module Entity {
        export module FormElement {
            export module State {
                export module Enum {

                    /**
                     * Every form have three states
                     * first - before sending information to database
                     * second - we waiting response from remote server.
                     * third - if you something is not correct and our information can't be saved in database.
                     * Note: f you information is correct from Loading state, we should to back to normal state.
                     */
                    export enum FormState {
                        Normal,
                        Loading,
                        Error
                    };
                }
            }
        }
    }
}