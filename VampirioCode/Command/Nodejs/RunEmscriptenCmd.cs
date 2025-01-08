using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.Nodejs
{
    public class RunEmscriptenCmd : BaseCmd
    {
        public string Filename { get; set; } = "";

        public async Task<RunEmscriptenResult> RunAsync()
        {
            LogParams = false;
            AutoTriggerErrors = false;
            //return await CreateCommand<RunResultEmscripten>(_quotes(Nodejs.ProgramPath), _quotes(Filename));
            return await CreateCommand<RunEmscriptenResult>(_quotes(Config.BuildersSettings.Emscripten.nodejs_exe_path), _quotes(Filename));
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
