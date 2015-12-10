/// <reference path="basemodel.ts" />

module Myteletouch {
    "use strict";

    export module Model {
        export class Product extends BaseModel {
            private _InternalCode: string;
            private _ImagePath: string;
            private _UnitPrice: number;

            constructor() {
                super();

                this._InternalCode = null;
            }

            get Id(): number {
                return this.Id;
            }

            get InternalCode(): string {
                return this._InternalCode;
            }

            set InternalCode(newValue: string) {
                this._InternalCode = newValue;
            }

            get ImagePath(): string {
                return this._InternalCode;
            }

            set ImagePath(newValue: string) {
                this._ImagePath = newValue;
            }

            get UnitPrice(): number {
                return this._UnitPrice;
            }

            set UnitPrice(newValue: number) {
                this._UnitPrice = newValue;
            }
        }
    }
}