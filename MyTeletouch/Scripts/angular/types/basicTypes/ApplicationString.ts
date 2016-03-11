module Type {
    "use strict";

    export module BaseType {
        export class ApplicationString {

            /**
             * Indicates whether the specified string is null or an Empty string.
             *
             * @property string inputString
             * @see https://msdn.microsoft.com/en-us/library/system.string.isnullorempty(v=vs.110).aspx
             */
            static isNullOrEmpty(inputString: string): boolean {
                if (inputString === undefined || inputString === null || inputString.length === 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}