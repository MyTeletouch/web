using System;
using System.Web.Mvc;

namespace ViewHelpers
{
    public class LinkHelper
    {
        /// <summary>
        /// Generate link rel HTML.
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/2293357/what-is-an-mvchtmlstring-and-when-should-i-use-it#_=_"/>
        /// <param name="type"></param>
        /// <param name="hrefLocation"></param>
        /// <returns></returns>
        public static MvcHtmlString Link(string type, string hrefLocation)
        {
            // string urlContent = Url.Content
            string link = String.Format("<link rel=\"{0}\" href=\"{1}\" />", type, hrefLocation);
            var mvcOutput = new MvcHtmlString(link);

            return mvcOutput;
        }

        /// <summary>
        /// Generate link rel HTML import.
        /// </summary>
        /// <param name="hrefLocation"></param>
        /// <returns></returns>
        public static MvcHtmlString LinkImport(string hrefLocation)
        {
            return Link("import", hrefLocation);
        }
    }
}
