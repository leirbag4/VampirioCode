using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Utils
{
    public class Utility
    {
        public static string ReplaceLast(string str, string oldValue, string newValue)
        {
            int index = str.IndexOf(oldValue);

            if(index == -1)
                return oldValue;

            string part0 = str.Substring(0, index);
            string part1 = str.Substring(index + oldValue.Length);
            return part0 + newValue + part1;
        }
    }
}
