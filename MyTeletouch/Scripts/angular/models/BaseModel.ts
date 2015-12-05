module Myteletouch {
    "use strict";

    export module Model {
        export class BaseModel {
            private _Id: number;

            constructor() {
                this._Id = null;
            }

            get Id(): number {
                return this._Id;
            }
        }
    }
}