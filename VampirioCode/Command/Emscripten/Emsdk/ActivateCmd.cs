using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;
using VampirioCode.UI;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class ActivateCmd : BaseCmd
    {
        /// </summary>
        /// <param name="version">A name or|and version number to activate the sdk like '3.1.53' or 'latest' or any other tool or sdk lile 'node-0.10.17-64bit'. If you leave it as it is, 'latest' will be used.</param>
        /// <returns></returns>
        public string ToolOrSdk = "latest";

        /// <summary>
        /// On Windows, you can pass the option --permanent to the activate command to register the environment permanently for the current user.
        /// </summary>
        public bool Permanent = false;

        /// <summary>
        /// On Windows, you can pass the option --system to the activate command to register the environment permanently for all users.
        /// </summary>
        public bool System = false;



        public async Task<ActivateResult> ActivateAsync()
        {
            Set(ToolOrSdk);
            Set("--permanent", Permanent);
            Set("--system", System);
            AutoTriggerErrors = false;
            return await CreateCommand<ActivateResult>(_quotes(Emsdk.ProgramPath), "activate", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            if (data.Contains("error: ")) 
                CallError(data);
            else
                Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            // errors are not errors here
            Println(data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }

    }
}
