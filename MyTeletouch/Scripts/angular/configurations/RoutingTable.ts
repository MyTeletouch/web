module Myteletouch {
    "use strict";

    export module Configurations {
        export class RoutingTable {
            private static CURRENT_VERSION = 'v1';
            private static MAIN_TEMPLATE = `api/${RoutingTable.CURRENT_VERSION}`;

            /**
             * Get information for database countries.
             *
             * @param {String} locale
             */
            public static countryList(locale: string) {
                const templateURI = RoutingTable.createRouteTemplate(locale);

                return `${ templateURI }/countries/countrylist`;
            }

            /**
             * @param {String} internalCode Databse product unique name
             * @param {String} locale
             */
            public static productInfoByInternalCode(internalCode: string, locale: string) {
                const templateURI = RoutingTable.createRouteTemplate(locale);

                return `${ templateURI }/products/byinternalcode/${internalCode}`;
            }

            /**
             * Create route template structure.
             * 
             * @param {String} locale
             */
            public static createRouteTemplate(locale: string) {
                return `${RoutingTable.MAIN_TEMPLATE}/${locale}`;
            }
        } 
    }
}