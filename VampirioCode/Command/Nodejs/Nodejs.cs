using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs.Result;

namespace VampirioCode.Command.Nodejs
{
    public class Nodejs : BaseCmdProgram
    {
        public static string ProgramPath = @"C:\programs_dev\node-v20.11.0-win-x64\node.exe";

        /// <summary>
        /// Run the script file '.js'
        /// </summary>
        /// <param name="filename">The javascript file '.js' to run</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(string filename)
        {
            RunCmd cmd = new RunCmd();
            cmd.Filename = filename;
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }
    }
}
