module Myteletouch {
    "use strict";

    export module Model {
        export module ViewModel {
            export module ProductViewModel {
                export class ProductTotalCostItem {
                    public Id: number;

                    private _ProductViewModelItemInfo: Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem;
                    private _Quantity: number;
                    private _TotalCost: number;
                    
                    constructor(productViewModelItemInfo: Myteletouch.Model.ViewModel.ProductViewModel.ProductViewModelItem) {

                        this.Id = productViewModelItemInfo.Id;
                        this._ProductViewModelItemInfo = productViewModelItemInfo;

                        // We always start from 1 item.
                        this.Quantity = 1;
                    }

                    get Quantity(): number {
                        return this._Quantity;
                    }

                    set Quantity(newValue: number) {
                        // Prevent injections
                        if (newValue < 1) {
                            newValue = 1;
                        }

                        this._Quantity = newValue;

                        // Re calculate total cost
                        this._TotalCost = this._ProductViewModelItemInfo.UnitPrice * this.Quantity;
                    }

                    get TotalCost(): number {
                        return this._TotalCost;
                    }

                    totalCostFormatted(): string {
                        return this.TotalCost.toFixed(2);
                    }
                }
            }
        }
    }
}