using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class HelpCmd : BaseCmd
    {

        public async Task<HelpResult> HelpAsync()
        {
            return await CreateCommand<HelpResult>(Emsdk.ProgramPath, "help");
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("error: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }
    }
}
