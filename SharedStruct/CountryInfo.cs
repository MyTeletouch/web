using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedStruct
{
    public class CountryInfo
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public CountryInfo(string Code, string Name)
        {
            this.CountryCode = Code;
            this.CountryName = Name;
        }
    }
}
