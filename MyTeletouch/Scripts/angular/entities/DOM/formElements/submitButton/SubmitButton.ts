/// <reference path="submitbuttonstate.ts" />

module Myteletouch {
    "use strict";

    export module Entity {
        export module DOM {
            export module FormElement {
                export module SubmitButton {

                    type State = Myteletouch.Entity.DOM.FormElement.SubmitButton.Enum.State;

                    /**
                     * Class should to store: 
                     * different SubmitButton State and which is current state of button.
                     */
                    export class SubmitButton {

                        public state: State;
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

                        backToNormalState(): void {
                            this.label = this.labelNormalState;
                            this.state = Myteletouch.Entity.DOM.FormElement.SubmitButton.Enum.State.Normal;
                        }

                        /**
                            * Now we waiting response from remote server.
                            */
                        changeToLoadingState(): void {
                            this.label = this.labelLoadingState;
                            this.state = Myteletouch.Entity.DOM.FormElement.SubmitButton.Enum.State.Loading;
                        }

                        changeToErrorState(): void {
                            this.label = this.labelErrorState;
                            this.state = Myteletouch.Entity.DOM.FormElement.SubmitButton.Enum.State.Error;
                        }
                    }
                }
            }
        }
    }
}