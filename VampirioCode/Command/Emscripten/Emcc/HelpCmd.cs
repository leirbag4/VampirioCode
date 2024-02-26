using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emcc.Result;

namespace VampirioCode.Command.Emscripten.Emcc
{
    public class HelpCmd : BaseCmd
    {
        public async Task<HelpResult> VersionAsync()
        {
            return await CreateCommand<HelpResult>("emcc", "--help");
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
