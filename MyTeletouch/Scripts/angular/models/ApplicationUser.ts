module Myteletouch {
    "use strict";

    export module Model {
        export class ApplicationUser  {
            private _Id: string;
            private _Email: string;
            private _Username: string;

            constructor() {
                this._Id = null;
                this._Email = null;
                this._Username = null;
            }

            get Id(): string {
                return this._Id;
            }

            get Email(): string {
                return this._Email;
            }

            set Email(newValue: string) {
                this._Email = newValue;
                // Temporary username will be equal to email
                this._Username = newValue;
            }

            get Username(): string {
                return this._Username;
            }

            set Username(newValue: string) {
                this._Username = newValue;
            }
        }
    }
}