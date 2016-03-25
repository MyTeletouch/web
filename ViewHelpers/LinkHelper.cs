using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewHelpers
{
    public class LinkHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hrefLocation"></param>
        /// <returns></returns>
        public static string Link(string type, string hrefLocation)
        {
            // string urlContent = Url.Content
            string link = String.Format("<link rel='{0}' href='{1}'/>", type, hrefLocation);

            return link;
        }
    }
}
