using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs.Result;

namespace VampirioCode.Command.Nodejs
{
    public class RunCmd : BaseCmd
    {
        public string Filename { get; set; } = "";

        public async Task<RunResult> RunAsync()
        {
            LogParams = false;
            AutoTriggerErrors = false;
            return await CreateCommand<RunResult>(_quotes(Nodejs.ProgramPath), _quotes(Filename));
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("Error: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }

    }
}
