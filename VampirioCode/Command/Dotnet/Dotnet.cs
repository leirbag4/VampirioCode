using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Result;
using static System.Runtime.InteropServices.JavaScript.JSType;
using VampirioCode.IO;

namespace VampirioCode.Command.Dotnet
{
    public class Dotnet
    {
        public ErrorInfo ErrorInfo { get; private set; } = null;
        public bool Error { get; private set; } = false;

        public async Task<BuildResult> BuildAsync()
        { 
            BuildCmd cmd = new BuildCmd();
            var result = await cmd.BuildAsync();
            CheckCmd(cmd);

            return result;
        }

        private void CheckCmd(BaseCmd cmd)
        {
            if (cmd.Error)
            {
                ErrorInfo = cmd.ErrorInfo;
                Error = true;
            }
        }

    }
}
