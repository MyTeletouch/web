using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Resources
{
    public static class CultureHelper
    {
        // Valid cultures
        private static readonly List<string> _validCultures = new List<string>
        {
            "af", "af-ZA", "sq", "sq-AL", "gsw-FR", "am-ET", "ar", "ar-DZ", "ar-BH", "ar-EG", "ar-IQ", "ar-JO", "ar-KW", "ar-LB", "ar-LY", "ar-MA", "ar-OM", "ar-QA", "ar-SA", "ar-SY", "ar-TN", "ar-AE", "ar-YE", "hy", "hy-AM", "as-IN", "az", "az-Cyrl-AZ", "az-Latn-AZ", "ba-RU", "eu", "eu-ES", "be", "be-BY", "bn-BD", "bn-IN", "bs-Cyrl-BA", "bs-Latn-BA", "br-FR", "bg", "bg-BG", "ca", "ca-ES", "zh-HK", "zh-MO", "zh-CN", "zh-Hans", "zh-SG", "zh-TW", "zh-Hant", "co-FR", "hr", "hr-HR", "hr-BA", "cs", "cs-CZ", "da", "da-DK", "prs-AF", "div", "div-MV", "nl", "nl-BE", "nl-NL", "en", "en-AU", "en-BZ", "en-CA", "en-029", "en-IN", "en-IE", "en-JM", "en-MY", "en-NZ", "en-PH", "en-SG", "en-ZA", "en-TT", "en-GB", "en-US", "en-ZW", "et", "et-EE", "fo", "fo-FO", "fil-PH", "fi", "fi-FI", "fr", "fr-BE", "fr-CA", "fr-FR", "fr-LU", "fr-MC", "fr-CH", "fy-NL", "gl", "gl-ES", "ka", "ka-GE", "de", "de-AT", "de-DE", "de-LI", "de-LU", "de-CH", "el", "el-GR", "kl-GL", "gu", "gu-IN", "ha-Latn-NG", "he", "he-IL", "hi", "hi-IN", "hu", "hu-HU", "is", "is-IS", "ig-NG", "id", "id-ID", "iu-Latn-CA", "iu-Cans-CA", "ga-IE", "xh-ZA", "zu-ZA", "it", "it-IT", "it-CH", "ja", "ja-JP", "kn", "kn-IN", "kk", "kk-KZ", "km-KH", "qut-GT", "rw-RW", "sw", "sw-KE", "kok", "kok-IN", "ko", "ko-KR", "ky", "ky-KG", "lo-LA", "lv", "lv-LV", "lt", "lt-LT", "wee-DE", "lb-LU", "mk", "mk-MK", "ms", "ms-BN", "ms-MY", "ml-IN", "mt-MT", "mi-NZ", "arn-CL", "mr", "mr-IN", "moh-CA", "mn", "mn-MN", "mn-Mong-CN", "ne-NP", "no", "nb-NO", "nn-NO", "oc-FR", "or-IN", "ps-AF", "fa", "fa-IR", "pl", "pl-PL", "pt", "pt-BR", "pt-PT", "pa", "pa-IN", "quz-BO", "quz-EC", "quz-PE", "ro", "ro-RO", "rm-CH", "ru", "ru-RU", "smn-FI", "smj-NO", "smj-SE", "se-FI", "se-NO", "se-SE", "sms-FI", "sma-NO", "sma-SE", "sa", "sa-IN", "sr", "sr-Cyrl-BA", "sr-Cyrl-SP", "sr-Latn-BA", "sr-Latn-SP", "nso-ZA", "tn-ZA", "si-LK", "sk", "sk-SK", "sl", "sl-SI", "es", "es-AR", "es-BO", "es-CL", "es-CO", "es-CR", "es-DO", "es-EC", "es-SV", "es-GT", "es-HN", "es-MX", "es-NI", "es-PA", "es-PY", "es-PE", "es-PR", "es-ES", "es-US", "es-UY", "es-VE", "sv", "sv-FI", "sv-SE", "syr", "syr-SY", "tg-Cyrl-TJ", "tzm-Latn-DZ", "ta", "ta-IN", "tt", "tt-RU", "te", "te-IN", "th", "th-TH", "bo-CN", "tr", "tr-TR", "tk-TM", "ug-CN", "uk", "uk-UA", "wen-DE", "ur", "ur-PK", "uz", "uz-Cyrl-UZ", "uz-Latn-UZ", "vi", "vi-VN", "cy-GB", "wo-SN", "sah-RU", "ii-CN", "yo-NG"
        };

        // Include ONLY cultures are supported
        private static readonly List<string> _supportedCultures = new List<string>
        {
            "en-US"
        };

        /// <summary>
        /// Returns true if the language is a right-to-left language. Otherwise, false.
        /// </summary>
        /// <returns></returns>
        public static bool IsRightToLeft()
        {
            bool isRightToLeft = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;

            return isRightToLeft;
        }

        /// <summary>
        /// Returns a valid culture name based on "name" parameter.
        /// If "name" is not valid, it returns the default culture "en-US".
        /// </summary>
        /// <param name="name">Culture's name(e.g. en-US)</param>
        /// <returns></returns>
        public static string GetImplementedCulture(string name)
        {
            // make sture it's not null
            if (string.IsNullOrEmpty(name))
            {
                return GetDefaultCulture();
            }

            // make sure it is a valid culture first
            int totalMatchesInValidCultures = GetTotalMatchesByPatternInCollection(_validCultures, name);
            if (totalMatchesInValidCultures == 0)
            {
                return GetDefaultCulture();
            }

            // if it is implemented, accept it
            int totalMatchesInSupportedCultures = GetTotalMatchesByPatternInCollection(_supportedCultures, name);
            if (totalMatchesInSupportedCultures > 0)
            {
                return name;
            }

            return GetClosestMatch(name);
        }

        /// <summary>
        /// Returns default culture name which is the first name decalared (e.g. en-US)
        /// If you <see cref="_supportedCultures"/> is empty list will throw exceptio 
        /// </summary>
        /// <returns>Culture's name(e.g. en-US)</returns>
        public static string GetDefaultCulture()
        {
            if (_supportedCultures.Count > 0)
            {
                return _supportedCultures.First(); // Return Default culture
            }
            else
            {
                throw new Exception("Please set at least one _supportedCulture");
            }
        }

        /// <summary>
        /// If you our pattern contains delimiter '-': We should to return first part of string.
        /// If you our pattern not contains delimiter '-': We will return all pattern.
        /// 1) We make splirt and re 
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string GetNeutralCulture(string pattern)
        {
            if (pattern.Contains("-"))
            {
                // Read first part only. E.g. "en", "es" 
                return pattern.Split('-')[0];
            }
            else
            {
                return pattern;
            }
        }

        /// <summary>
        /// Method extraxt unique locales information from <see cref="_supportedCultures"/>.
        /// </summary>
        /// <returns>If you we <see cref="_supportedCultures"/> is equal to "en-US", "es-US", "en-UK" we should to return ["en", "es"].</returns>
        public static HashSet<string> GetSupportedLocales()
        {
            HashSet<string> supportedLocales = new HashSet<string>();
            string[] locales;

            foreach (string supportedCulture in _supportedCultures)
            {
                locales = Regex.Split(supportedCulture, "-");

                if (locales.Length > 0 && supportedLocales.Contains(locales[0]))
                {
                    supportedLocales.Add(locales[0]);
                }
            }

            return supportedLocales;
        }

        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// Get total matches for the collection by string pattern. 
        /// </summary>
        /// <param name="collection">Reference to <see cref="_validCultures"/> or <see cref="_supportedCultures"/> </param>
        /// <param name="name">Culture's name(e.g. en-US)</param>
        /// <returns></returns>
        private static int GetTotalMatchesByPatternInCollection(List<string> collection, string pattern)
        {
            int count = collection.Where(c => c.Equals(pattern, StringComparison.InvariantCultureIgnoreCase)).Count();

            return count;
        }

        /// <summary>
        /// Find a close match. For example, if you have "en-US" defined and the user requests "en-GB"
        /// the function will return match that is "en-US", because at least the language is the same (ie English)
        /// </summary>
        /// <param name="pattern">Culture's name(e.g. en-GB)</param>
        /// <returns></returns>
        private static string GetClosestMatch(string pattern)
        {
            var neuturalCulture = GetNeutralCulture(pattern);

            foreach (var culture in _supportedCultures)
            {
                if (culture.StartsWith(neuturalCulture))
                {
                    return culture;
                }
            }

            return GetDefaultCulture();
        }
    }
}
