using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.BuilderSetting.Actions
{
    public class CopyDirAction
    {
        public bool Overwrite { get; set; } = true;
        public string From { get; set; }
        public string To { get; set; }
    }
}
