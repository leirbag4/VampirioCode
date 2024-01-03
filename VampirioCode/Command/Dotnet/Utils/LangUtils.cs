using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Utils
{
    public class LangUtils
    {
        public static string[] SplitLanguages(string data)
        {
            string[] str = data.Split(',');
            List<string> langs = new List<string>();

            foreach (string s in str)
            {
                // remove [] from for example -> [C#]
                langs.Add(s.Trim().Replace("[", "").Replace("]", ""));
            }

            return langs.ToArray();
        }
    }
}
