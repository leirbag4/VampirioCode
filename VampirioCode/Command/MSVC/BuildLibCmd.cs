using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.MSVC.Result;
using VampirioCode.Properties;

namespace VampirioCode.Command.MSVC
{
    public class BuildLibCmd : BaseCmd
    {
        /// <summary>
        /// The .obj files that will be compiled into a '.lib'
        /// E.g: engine.obj  engine_ui.obj
        /// </summary>
        public List<string> ObjectFiles { get; set; } = new List<string>();

        /// <summary>
        /// The output file name of the library. E.g: game_engine.lib
        /// Its extension must be '.lib'
        /// </summary>
        public string LibOutputFilename { get; set; } = "";

        public async Task<BuildLibresult> BuildAsync()
        {
            SetIfExists("/OUT:", _fixLastEscapeBar(LibOutputFilename), false);

            SetIfExists(ObjectFiles.ToArray());

            AutoTriggerErrors = false;
            return await CreateCommand<BuildLibresult>(_quotes(MSVC.LibProgramPath), cmd.Trim());
        }

        protected override void OnErrorDataReceived(string data)
        {
            Println("error: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }
    }
}
