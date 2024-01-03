using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Models;

namespace VampirioCode.Command.Dotnet.Result
{
    public class NewSearchResult : BaseResult
    {
        public STemplate[] Templates { get; set; }

        public override string ToString()
        {
            string str = "";

            foreach (var template in Templates)
                str += template.ToString() + "\n";

            return str;
        }
    }
}
