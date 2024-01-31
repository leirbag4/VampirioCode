using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.IO;

namespace VampirioCode.Command
{
    public class BaseCmdProgram
    {
        public ErrorInfo ErrorInfo { get; private set; } = null;
        public bool Error { get; private set; } = false;

        protected void CheckCmd(BaseCmd cmd)
        {
            if (cmd.Error)
            {
                ErrorInfo = cmd.ErrorInfo;
                Error = true;
            }
        }
    }
}
