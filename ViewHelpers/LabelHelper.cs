using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewHelpers
{
    public class LabelHelper
    {
        /// <summary>
        /// Create a custom label.
        /// <seealso cref="http://www.asp.net/mvc/overview/older-versions-1/views/creating-custom-html-helpers-cs"/>
        /// 
        /// </summary>
        /// <param name="target">Information for "for" attribute.</param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Label(string target, string text)
        {
            string label = String.Format("<label for='{0}'>{1}</label>", target, text);

            return label;
        }
    }
}
