using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.Nodejs
{
    public class Nodejs : BaseCmdProgram
    {
        //public static string ProgramPath = @"C:\programs_dev\node-v20.11.0-win-x64\node.exe";
        public static string ProgramPath = "";

        /// <summary>
        /// Run the script file '.js'
        /// </summary>
        /// <param name="filename">The javascript file '.js' to run</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(string filename)
        {
            SetupProgramPaths();

            RunCmd cmd = new RunCmd();
            cmd.Filename = filename;
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Run the script file '.js' for Emscripten
        /// </summary>
        /// <param name="filename">The javascript file '.js' to run</param>
        /// <returns></returns>
        public async Task<RunEmscriptenResult> RunEmscriptenAsync(string filename)
        {
            SetupProgramPaths();

            RunEmscriptenCmd cmd = new RunEmscriptenCmd();
            cmd.Filename = filename;
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            ProgramPath = Config.BuildersSettings.NodeJs.nodejs_exe_path;
        }
    }
}
