/// <reference path="formstate.ts" />

module Myteletouch {
    "use strict";

    export module Entity {
        export module DOM {
            export module FormElement {
                export module Form {

                    type State = Myteletouch.Entity.DOM.FormElement.Form.Enum.State;

                    export class Form {

                        public state: State;
                        public className: string;

                        private classNormalState: string = "";
                        private classSuccessState: string = "";
                        private classErrorState: string = "";

                        constructor(private normalStateClass: string, private successStateClass: string, private errorStateClass: string) {
                            this.classNormalState = normalStateClass;
                            this.classSuccessState = successStateClass;
                            this.classErrorState = errorStateClass;

                            this.backToNormalState();
                        }

                        backToNormalState(): void {
                            this.className = this.classNormalState;
                            this.state = Myteletouch.Entity.DOM.FormElement.Form.Enum.State.Normal;
                        }

                        changeToSuccessState(): void {
                            this.className = this.classSuccessState;
                            this.state = Myteletouch.Entity.DOM.FormElement.Form.Enum.State.Success;
                        }

                        changeToErrorState(): void {
                            this.className = this.errorStateClass;
                            this.state = Myteletouch.Entity.DOM.FormElement.Form.Enum.State.Error;
                        }
                    }
                }
            }
        }
    }
}