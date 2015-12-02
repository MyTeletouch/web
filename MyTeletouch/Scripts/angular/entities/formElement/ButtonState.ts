module Myteletouch {
    "use strict";

    export module Entity {
        export module FormElement {

            export enum State {
                Normal,
                Error,
                Loading
            };

            /**
             * Class should to store different Button State and which is current state of button.
             */
            export class ButtonState {

                public ButtonState: Myteletouch.Entity.FormElement.State;
                public currentStateLabel: string = "";
                public normalStateLabel: string = "";
                public errorStateLabel: string = "";
                public loadingStateLabel: string = "";

                constructor(normalStateLabel: string, errorStateLabel: string, loadingStateLabel: string) {
                    this.normalStateLabel = normalStateLabel;
                    this.errorStateLabel = errorStateLabel;
                    this.loadingStateLabel = loadingStateLabel;

                    this.currentStateLabel = this.normalStateLabel;
                }
            }
        }
    }
}