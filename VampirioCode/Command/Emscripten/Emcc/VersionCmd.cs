using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emcc.Result;

namespace VampirioCode.Command.Emscripten.Emcc
{
    public class VersionCmd : BaseCmd
    {

        public async Task<VersionResult> VersionAsync()
        {
            return await CreateCommand<VersionResult>("emcc", "--version");
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
