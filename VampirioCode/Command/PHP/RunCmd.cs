using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.PHP.Result;

namespace VampirioCode.Command.PHP
{
    public class RunCmd : BaseCmd
    {
        public string Filename { get; set; } = "";

        public async Task<RunResult> RunAsync()
        {
            LogParams = false;
            AutoTriggerErrors = false;
            return await CreateCommand<RunResult>(_quotes(PHP.ProgramPath), _quotes(Filename));
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            if (data.IndexOf("Unable to load dynamic library") == -1)
                PrintError("Error: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }

    }
}
