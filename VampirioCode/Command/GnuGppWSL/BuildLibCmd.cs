using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.UI;

namespace VampirioCode.Command.GnuGppWSL
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

        public async Task<BuildLibResult> BuildAsync()
        {
            SetIfExists(LibOutputFilename);
            SetIfExists(ObjectFiles.ToArray());

            AutoTriggerErrors = false;
            ConfirmProgramPath = false;

            return await CreateCommand<BuildLibResult>("wsl", $"-d {GnuGppWSL.DistroName} ar rcs", cmd.Trim());
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
