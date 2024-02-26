using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class ListCmd : BaseCmd
    {

        /// <summary>
        /// With the --old parameter, historical versions are also shown.
        /// </summary>
        public bool Old = false;

        /// <summary>
        /// Lists all current SDKs and tools and their installation status.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResult> ListAsync()
        {
            Set("--old", Old);
            return await CreateCommand<ListResult>(Emsdk.ProgramPath, "list", cmd.Trim());
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
