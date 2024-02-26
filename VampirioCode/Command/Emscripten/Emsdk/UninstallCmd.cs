using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class UninstallCmd : BaseCmd
    {
        /// </summary>
        /// <param name="version">A name or|and version number to activate the sdk like '3.1.53' or 'latest' or any other tool or sdk lile 'node-0.10.17-64bit'. If you leave it as it is, 'latest' will be used.</param>
        /// <returns></returns>
        public string ToolOrSdk = "latest";

        public async Task<UninstallResult> UninstallAsync()
        {
            Set(ToolOrSdk);
            return await CreateCommand<UninstallResult>(Emsdk.ProgramPath, "uninstall", cmd.Trim());
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
