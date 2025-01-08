using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class UpdateCmd : BaseCmd
    {

        public async Task<UpdateResult> UpdateAsync()
        {
            //return await CreateCommand<UpdateResult>(Emsdk.ProgramPath, "update");
            return await CreateCommand<UpdateResult>(Config.BuildersSettings.Emscripten.emsdk_bat_path, "update");
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
