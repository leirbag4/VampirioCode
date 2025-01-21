using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Clang
{
    public class BuildLibResult : BaseResult
    {
        public string LibOutputFilename { get; set; } = "";
    }
}
