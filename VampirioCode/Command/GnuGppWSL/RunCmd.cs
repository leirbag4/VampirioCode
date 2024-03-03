using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.Properties;

namespace VampirioCode.Command.GnuGppWSL
{
    public class RunCmd : BaseCmd
    {
        public string Filename { get; set; } = "";

        public async Task<RunResult> RunAsync()
        {
            LogParams = false;
            return await CreateCommand<RunResult>("wsl", "-d Ubuntu-test", _quotes(Filename));
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError(data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }
    }
}
