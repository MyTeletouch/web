module Myteletouch {
    "use strict";

    export module Model {
        export class BaseModel {
            private _Id: any;

            constructor() {
                this._Id = null;
            }

            get Id(): any {
                return this._Id;
            }
        }
    }
}