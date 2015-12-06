using MyTeletouch.Entities;
using MyTeletouch.Repositories;
using MyTeletouch.Repositories.Intefraces;
using Resources;
using SharedStruct;
using System.Collections.Generic;

namespace MyTeletouch.Seeds
{
    public class CountryList
    {
        private readonly ICountryRepository _dbRepository = new CountryRepository();

        public struct CountryLocaleList
        {
            public string Locale { get; set; } 
            public List<CountryInfo> Countries { get; set; }

            public CountryLocaleList(string SystemLocale, List<CountryInfo> SystemCountries)
            {
                this.Locale = SystemLocale;
                this.Countries = SystemCountries;
            }
        }

        /// <summary>
        /// Method will insert only countries, who don't exist in database.
        /// </summary>
        public void InsertCountries()
        {
            HashSet<string> locales = CultureHelper.GetSupportedLocales();
            List<CountryLocaleList> availableCountries = new List<CountryLocaleList>();

            foreach (var locale in locales)
            {
                // Get information for english speakers in our system
                if (locale.Equals("en"))
                {
                    List<CountryInfo> englishLocales = GenerateCountriesForEnglishCulture();
                    availableCountries.Add(new CountryLocaleList(locale, englishLocales));
                }
            }

            InsertAvailableCountries(availableCountries);
        }

        private void InsertAvailableCountries(List<CountryLocaleList> availableCountries)
        {
            CountryText countryLocale;
            foreach (CountryLocaleList countryRowRecord in availableCountries)
            {
                // Insert for each locale country information.
                foreach (CountryInfo countryInfo in countryRowRecord.Countries)
                {
                    countryLocale = new CountryText();

                    // Insert Country
                    countryLocale.CountryId = _dbRepository.AddCountry(countryInfo);
                    countryLocale.Locale = countryRowRecord.Locale;
                    countryLocale.Name = countryInfo.CountryName;

                    _dbRepository.AddOrUpdateCountryLocale(countryLocale);
                }
            }
        }

        /// <summary>
        /// Generate list, who will be able to use from English speakers in our system.
        /// </summary>
        /// <returns></returns>
        private static List<CountryInfo> GenerateCountriesForEnglishCulture()
        {
            List<CountryInfo> englishLocales = new List<CountryInfo>();

            englishLocales.Add(new CountryInfo("AD", "Andorra"));
            englishLocales.Add(new CountryInfo("AE", "United Arab Emirates"));
            englishLocales.Add(new CountryInfo("AF", "Afghanistan"));
            englishLocales.Add(new CountryInfo("AG", "Antigua and Barbuda"));
            englishLocales.Add(new CountryInfo("AI", "Anguilla"));
            englishLocales.Add(new CountryInfo("AL", "Albania"));
            englishLocales.Add(new CountryInfo("AM", "Armenia"));
            englishLocales.Add(new CountryInfo("AO", "Angola"));
            englishLocales.Add(new CountryInfo("AQ", "Antarctica"));
            englishLocales.Add(new CountryInfo("AR", "Argentina"));
            englishLocales.Add(new CountryInfo("AS", "American Samoa"));
            englishLocales.Add(new CountryInfo("AT", "Austria"));
            englishLocales.Add(new CountryInfo("AU", "Australia"));
            englishLocales.Add(new CountryInfo("AW", "Aruba"));
            englishLocales.Add(new CountryInfo("AX", "Åland"));
            englishLocales.Add(new CountryInfo("AZ", "Azerbaijan"));
            englishLocales.Add(new CountryInfo("BA", "Bosnia and Herzegovina"));
            englishLocales.Add(new CountryInfo("BB", "Barbados"));
            englishLocales.Add(new CountryInfo("BD", "Bangladesh"));
            englishLocales.Add(new CountryInfo("BE", "Belgium"));
            englishLocales.Add(new CountryInfo("BF", "Burkina Faso"));
            englishLocales.Add(new CountryInfo("BG", "Bulgaria"));
            englishLocales.Add(new CountryInfo("BH", "Bahrain"));
            englishLocales.Add(new CountryInfo("BI", "Burundi"));
            englishLocales.Add(new CountryInfo("BJ", "Benin"));
            englishLocales.Add(new CountryInfo("BL", "Saint Barthélemy"));
            englishLocales.Add(new CountryInfo("BM", "Bermuda"));
            englishLocales.Add(new CountryInfo("BN", "Brunei"));
            englishLocales.Add(new CountryInfo("BO", "Bolivia"));
            englishLocales.Add(new CountryInfo("BQ", "Bonaire"));
            englishLocales.Add(new CountryInfo("BR", "Brazil"));
            englishLocales.Add(new CountryInfo("BS", "Bahamas"));
            englishLocales.Add(new CountryInfo("BT", "Bhutan"));
            englishLocales.Add(new CountryInfo("BV", "Bouvet Island"));
            englishLocales.Add(new CountryInfo("BW", "Botswana"));
            englishLocales.Add(new CountryInfo("BY", "Belarus"));
            englishLocales.Add(new CountryInfo("BZ", "Belize"));
            englishLocales.Add(new CountryInfo("CA", "Canada"));
            englishLocales.Add(new CountryInfo("CC", "Cocos [Keeling] Islands"));
            englishLocales.Add(new CountryInfo("CD", "Democratic Republic of the Congo"));
            englishLocales.Add(new CountryInfo("CF", "Central African Republic"));
            englishLocales.Add(new CountryInfo("CG", "Republic of the Congo"));
            englishLocales.Add(new CountryInfo("CH", "Switzerland"));
            englishLocales.Add(new CountryInfo("CI", "Ivory Coast"));
            englishLocales.Add(new CountryInfo("CK", "Cook Islands"));
            englishLocales.Add(new CountryInfo("CL", "Chile"));
            englishLocales.Add(new CountryInfo("CM", "Cameroon"));
            englishLocales.Add(new CountryInfo("CN", "China"));
            englishLocales.Add(new CountryInfo("CO", "Colombia"));
            englishLocales.Add(new CountryInfo("CR", "Costa Rica"));
            englishLocales.Add(new CountryInfo("CU", "Cuba"));
            englishLocales.Add(new CountryInfo("CV", "Cape Verde"));
            englishLocales.Add(new CountryInfo("CW", "Curacao"));
            englishLocales.Add(new CountryInfo("CX", "Christmas Island"));
            englishLocales.Add(new CountryInfo("CY", "Cyprus"));
            englishLocales.Add(new CountryInfo("CZ", "Czech Republic"));
            englishLocales.Add(new CountryInfo("DE", "Germany"));
            englishLocales.Add(new CountryInfo("DJ", "Djibouti"));
            englishLocales.Add(new CountryInfo("DK", "Denmark"));
            englishLocales.Add(new CountryInfo("DM", "Dominica"));
            englishLocales.Add(new CountryInfo("DO", "Dominican Republic"));
            englishLocales.Add(new CountryInfo("DZ", "Algeria"));
            englishLocales.Add(new CountryInfo("EC", "Ecuador"));
            englishLocales.Add(new CountryInfo("EE", "Estonia"));
            englishLocales.Add(new CountryInfo("EG", "Egypt"));
            englishLocales.Add(new CountryInfo("EH", "Western Sahara"));
            englishLocales.Add(new CountryInfo("ER", "Eritrea"));
            englishLocales.Add(new CountryInfo("ES", "Spain"));
            englishLocales.Add(new CountryInfo("ET", "Ethiopia"));
            englishLocales.Add(new CountryInfo("FI", "Finland"));
            englishLocales.Add(new CountryInfo("FJ", "Fiji"));
            englishLocales.Add(new CountryInfo("FK", "Falkland Islands"));
            englishLocales.Add(new CountryInfo("FM", "Micronesia"));
            englishLocales.Add(new CountryInfo("FO", "Faroe Islands"));
            englishLocales.Add(new CountryInfo("FR", "France"));
            englishLocales.Add(new CountryInfo("GA", "Gabon"));
            englishLocales.Add(new CountryInfo("GB", "United Kingdom"));
            englishLocales.Add(new CountryInfo("GD", "Grenada"));
            englishLocales.Add(new CountryInfo("GE", "Georgia"));
            englishLocales.Add(new CountryInfo("GF", "French Guiana"));
            englishLocales.Add(new CountryInfo("GG", "Guernsey"));
            englishLocales.Add(new CountryInfo("GH", "Ghana"));
            englishLocales.Add(new CountryInfo("GI", "Gibraltar"));
            englishLocales.Add(new CountryInfo("GL", "Greenland"));
            englishLocales.Add(new CountryInfo("GM", "Gambia"));
            englishLocales.Add(new CountryInfo("GN", "Guinea"));
            englishLocales.Add(new CountryInfo("GP", "Guadeloupe"));
            englishLocales.Add(new CountryInfo("GQ", "Equatorial Guinea"));
            englishLocales.Add(new CountryInfo("GR", "Greece"));
            englishLocales.Add(new CountryInfo("GS", "South Georgia and the South Sandwich Islands"));
            englishLocales.Add(new CountryInfo("GT", "Guatemala"));
            englishLocales.Add(new CountryInfo("GU", "Guam"));
            englishLocales.Add(new CountryInfo("GW", "Guinea-Bissau"));
            englishLocales.Add(new CountryInfo("GY", "Guyana"));
            englishLocales.Add(new CountryInfo("HK", "Hong Kong"));
            englishLocales.Add(new CountryInfo("HM", "Heard Island and McDonald Islands"));
            englishLocales.Add(new CountryInfo("HN", "Honduras"));
            englishLocales.Add(new CountryInfo("HR", "Croatia"));
            englishLocales.Add(new CountryInfo("HT", "Haiti"));
            englishLocales.Add(new CountryInfo("HU", "Hungary"));
            englishLocales.Add(new CountryInfo("ID", "Indonesia"));
            englishLocales.Add(new CountryInfo("IE", "Ireland"));
            englishLocales.Add(new CountryInfo("IL", "Israel"));
            englishLocales.Add(new CountryInfo("IM", "Isle of Man"));
            englishLocales.Add(new CountryInfo("IN", "India"));
            englishLocales.Add(new CountryInfo("IO", "British Indian Ocean Territory"));
            englishLocales.Add(new CountryInfo("IQ", "Iraq"));
            englishLocales.Add(new CountryInfo("IR", "Iran"));
            englishLocales.Add(new CountryInfo("IS", "Iceland"));
            englishLocales.Add(new CountryInfo("IT", "Italy"));
            englishLocales.Add(new CountryInfo("JE", "Jersey"));
            englishLocales.Add(new CountryInfo("JM", "Jamaica"));
            englishLocales.Add(new CountryInfo("JO", "Jordan"));
            englishLocales.Add(new CountryInfo("JP", "Japan"));
            englishLocales.Add(new CountryInfo("KE", "Kenya"));
            englishLocales.Add(new CountryInfo("KG", "Kyrgyzstan"));
            englishLocales.Add(new CountryInfo("KH", "Cambodia"));
            englishLocales.Add(new CountryInfo("KI", "Kiribati"));
            englishLocales.Add(new CountryInfo("KM", "Comoros"));
            englishLocales.Add(new CountryInfo("KN", "Saint Kitts and Nevis"));
            englishLocales.Add(new CountryInfo("KP", "North Korea"));
            englishLocales.Add(new CountryInfo("KR", "South Korea"));
            englishLocales.Add(new CountryInfo("KW", "Kuwait"));
            englishLocales.Add(new CountryInfo("KY", "Cayman Islands"));
            englishLocales.Add(new CountryInfo("KZ", "Kazakhstan"));
            englishLocales.Add(new CountryInfo("LA", "Laos"));
            englishLocales.Add(new CountryInfo("LB", "Lebanon"));
            englishLocales.Add(new CountryInfo("LC", "Saint Lucia"));
            englishLocales.Add(new CountryInfo("LI", "Liechtenstein"));
            englishLocales.Add(new CountryInfo("LK", "Sri Lanka"));
            englishLocales.Add(new CountryInfo("LR", "Liberia"));
            englishLocales.Add(new CountryInfo("LS", "Lesotho"));
            englishLocales.Add(new CountryInfo("LT", "Lithuania"));
            englishLocales.Add(new CountryInfo("LU", "Luxembourg"));
            englishLocales.Add(new CountryInfo("LV", "Latvia"));
            englishLocales.Add(new CountryInfo("LY", "Libya"));
            englishLocales.Add(new CountryInfo("MA", "Morocco"));
            englishLocales.Add(new CountryInfo("MC", "Monaco"));
            englishLocales.Add(new CountryInfo("MD", "Moldova"));
            englishLocales.Add(new CountryInfo("ME", "Montenegro"));
            englishLocales.Add(new CountryInfo("MF", "Saint Martin"));
            englishLocales.Add(new CountryInfo("MG", "Madagascar"));
            englishLocales.Add(new CountryInfo("MH", "Marshall Islands"));
            englishLocales.Add(new CountryInfo("MK", "Macedonia"));
            englishLocales.Add(new CountryInfo("ML", "Mali"));
            englishLocales.Add(new CountryInfo("MM", "Myanmar [Burma]"));
            englishLocales.Add(new CountryInfo("MN", "Mongolia"));
            englishLocales.Add(new CountryInfo("MO", "Macao"));
            englishLocales.Add(new CountryInfo("MP", "Northern Mariana Islands"));
            englishLocales.Add(new CountryInfo("MQ", "Martinique"));
            englishLocales.Add(new CountryInfo("MR", "Mauritania"));
            englishLocales.Add(new CountryInfo("MS", "Montserrat"));
            englishLocales.Add(new CountryInfo("MT", "Malta"));
            englishLocales.Add(new CountryInfo("MU", "Mauritius"));
            englishLocales.Add(new CountryInfo("MV", "Maldives"));
            englishLocales.Add(new CountryInfo("MW", "Malawi"));
            englishLocales.Add(new CountryInfo("MX", "Mexico"));
            englishLocales.Add(new CountryInfo("MY", "Malaysia"));
            englishLocales.Add(new CountryInfo("MZ", "Mozambique"));
            englishLocales.Add(new CountryInfo("NA", "Namibia"));
            englishLocales.Add(new CountryInfo("NC", "New Caledonia"));
            englishLocales.Add(new CountryInfo("NE", "Niger"));
            englishLocales.Add(new CountryInfo("NF", "Norfolk Island"));
            englishLocales.Add(new CountryInfo("NG", "Nigeria"));
            englishLocales.Add(new CountryInfo("NI", "Nicaragua"));
            englishLocales.Add(new CountryInfo("NL", "Netherlands"));
            englishLocales.Add(new CountryInfo("NO", "Norway"));
            englishLocales.Add(new CountryInfo("NP", "Nepal"));
            englishLocales.Add(new CountryInfo("NR", "Nauru"));
            englishLocales.Add(new CountryInfo("NU", "Niue"));
            englishLocales.Add(new CountryInfo("NZ", "New Zealand"));
            englishLocales.Add(new CountryInfo("OM", "Oman"));
            englishLocales.Add(new CountryInfo("PA", "Panama"));
            englishLocales.Add(new CountryInfo("PE", "Peru"));
            englishLocales.Add(new CountryInfo("PF", "French Polynesia"));
            englishLocales.Add(new CountryInfo("PG", "Papua New Guinea"));
            englishLocales.Add(new CountryInfo("PH", "Philippines"));
            englishLocales.Add(new CountryInfo("PK", "Pakistan"));
            englishLocales.Add(new CountryInfo("PL", "Poland"));
            englishLocales.Add(new CountryInfo("PM", "Saint Pierre and Miquelon"));
            englishLocales.Add(new CountryInfo("PN", "Pitcairn Islands"));
            englishLocales.Add(new CountryInfo("PR", "Puerto Rico"));
            englishLocales.Add(new CountryInfo("PS", "Palestine"));
            englishLocales.Add(new CountryInfo("PT", "Portugal"));
            englishLocales.Add(new CountryInfo("PW", "Palau"));
            englishLocales.Add(new CountryInfo("PY", "Paraguay"));
            englishLocales.Add(new CountryInfo("QA", "Qatar"));
            englishLocales.Add(new CountryInfo("RE", "Réunion"));
            englishLocales.Add(new CountryInfo("RO", "Romania"));
            englishLocales.Add(new CountryInfo("RS", "Serbia"));
            englishLocales.Add(new CountryInfo("RU", "Russia"));
            englishLocales.Add(new CountryInfo("RW", "Rwanda"));
            englishLocales.Add(new CountryInfo("SA", "Saudi Arabia"));
            englishLocales.Add(new CountryInfo("SB", "Solomon Islands"));
            englishLocales.Add(new CountryInfo("SC", "Seychelles"));
            englishLocales.Add(new CountryInfo("SD", "Sudan"));
            englishLocales.Add(new CountryInfo("SE", "Sweden"));
            englishLocales.Add(new CountryInfo("SG", "Singapore"));
            englishLocales.Add(new CountryInfo("SH", "Saint Helena"));
            englishLocales.Add(new CountryInfo("SI", "Slovenia"));
            englishLocales.Add(new CountryInfo("SJ", "Svalbard and Jan Mayen"));
            englishLocales.Add(new CountryInfo("SK", "Slovakia"));
            englishLocales.Add(new CountryInfo("SL", "Sierra Leone"));
            englishLocales.Add(new CountryInfo("SM", "San Marino"));
            englishLocales.Add(new CountryInfo("SN", "Senegal"));
            englishLocales.Add(new CountryInfo("SO", "Somalia"));
            englishLocales.Add(new CountryInfo("SR", "Suriname"));
            englishLocales.Add(new CountryInfo("SS", "South Sudan"));
            englishLocales.Add(new CountryInfo("ST", "São Tomé and Príncipe"));
            englishLocales.Add(new CountryInfo("SV", "El Salvador"));
            englishLocales.Add(new CountryInfo("SX", "Sint Maarten"));
            englishLocales.Add(new CountryInfo("SY", "Syria"));
            englishLocales.Add(new CountryInfo("SZ", "Swaziland"));
            englishLocales.Add(new CountryInfo("TC", "Turks and Caicos Islands"));
            englishLocales.Add(new CountryInfo("TD", "Chad"));
            englishLocales.Add(new CountryInfo("TF", "French Southern Territories"));
            englishLocales.Add(new CountryInfo("TG", "Togo"));
            englishLocales.Add(new CountryInfo("TH", "Thailand"));
            englishLocales.Add(new CountryInfo("TJ", "Tajikistan"));
            englishLocales.Add(new CountryInfo("TK", "Tokelau"));
            englishLocales.Add(new CountryInfo("TL", "East Timor"));
            englishLocales.Add(new CountryInfo("TM", "Turkmenistan"));
            englishLocales.Add(new CountryInfo("TN", "Tunisia"));
            englishLocales.Add(new CountryInfo("TO", "Tonga"));
            englishLocales.Add(new CountryInfo("TR", "Turkey"));
            englishLocales.Add(new CountryInfo("TT", "Trinidad and Tobago"));
            englishLocales.Add(new CountryInfo("TV", "Tuvalu"));
            englishLocales.Add(new CountryInfo("TW", "Taiwan"));
            englishLocales.Add(new CountryInfo("TZ", "Tanzania"));
            englishLocales.Add(new CountryInfo("UA", "Ukraine"));
            englishLocales.Add(new CountryInfo("UG", "Uganda"));
            englishLocales.Add(new CountryInfo("UM", "U.S. Minor Outlying Islands"));
            englishLocales.Add(new CountryInfo("US", "United States"));
            englishLocales.Add(new CountryInfo("UY", "Uruguay"));
            englishLocales.Add(new CountryInfo("UZ", "Uzbekistan"));
            englishLocales.Add(new CountryInfo("VA", "Vatican City"));
            englishLocales.Add(new CountryInfo("VC", "Saint Vincent and the Grenadines"));
            englishLocales.Add(new CountryInfo("VE", "Venezuela"));
            englishLocales.Add(new CountryInfo("VG", "British Virgin Islands"));
            englishLocales.Add(new CountryInfo("VI", "U.S. Virgin Islands"));
            englishLocales.Add(new CountryInfo("VN", "Vietnam"));
            englishLocales.Add(new CountryInfo("VU", "Vanuatu"));
            englishLocales.Add(new CountryInfo("WF", "Wallis and Futuna"));
            englishLocales.Add(new CountryInfo("WS", "Samoa"));
            englishLocales.Add(new CountryInfo("XK", "Kosovo"));
            englishLocales.Add(new CountryInfo("YE", "Yemen"));
            englishLocales.Add(new CountryInfo("YT", "Mayotte"));
            englishLocales.Add(new CountryInfo("ZA", "South Africa"));
            englishLocales.Add(new CountryInfo("ZM", "Zambia"));
            englishLocales.Add(new CountryInfo("ZW", "Zimbabwe"));

            return englishLocales;
        }
    }
}