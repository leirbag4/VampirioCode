using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.MSVC.Result;

namespace VampirioCode.Command.MSVC
{
    public class RunCmd : BaseCmd
    {
        public string Filename { get; set; } = "";

        public async Task<RunResult> RunAsync()
        {
            LogParams = false;
            return await CreateCommand<RunResult>(Filename, "", "", "", true);
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }

    }
}
