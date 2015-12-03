/// <reference path="enums/formstate.ts" />

module Myteletouch {
    "use strict";

    export module Entity {
        export module FormElement {

            type FormState = Myteletouch.Entity.FormElement.State.Enum.FormState;

            /**
             * Class should to store: 
             * different SubmitButton State and which is current state of button.
             */
            export class SubmitButton {

                public state: FormState;
                public label: string = "";

                private labelNormalState: string = "";
                private labelLoadingState: string = "";
                private labelErrorState: string = "";

                constructor(private normalStateTextMessage: string, private loadingStateTextMessage: string, private errorStateTextMessage: string) {
                    this.labelNormalState = normalStateTextMessage;
                    this.labelLoadingState = loadingStateTextMessage;
                    this.labelErrorState = errorStateTextMessage;

                    this.backToNormalState();
                }

                backToNormalState() {
                    this.label = this.labelNormalState;
                    this.state = Myteletouch.Entity.FormElement.State.Enum.FormState.Normal;
                }

                /**
                    * Now we waiting response from remote server.
                    */
                changeToLoadingState() {
                    this.label = this.labelLoadingState;
                    this.state = Myteletouch.Entity.FormElement.State.Enum.FormState.Loading;
                }

                changeToErrorState() {
                    this.label = this.labelErrorState;
                    this.state = Myteletouch.Entity.FormElement.State.Enum.FormState.Error;
                }
            }
        }
    }
}