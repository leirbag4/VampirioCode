using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Result;

namespace VampirioCode.Command.GnuGppWSL
{
    public class GnuGppWSL : BaseCmdProgram
    {

        public async Task<BuildResult> BuildAsync(List<string> sources, string outputFilename = "")
        { 
            BuildCmd cmd = new BuildCmd();
            cmd.Sources = sources;
            cmd.OutputFilename = outputFilename;
            var result = await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<BuildResult> BuildAsync(BuildCmd cmd)
        {
            var result = await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Run the compiled executable
        /// </summary>
        /// <param name="filename">The executable file to run</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(string filename)
        {
            RunCmd cmd = new RunCmd();
            cmd.Filename = filename;
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Run the compiled executable by using the cmd as parameter
        /// </summary>
        /// <param name="cmd">The run command</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(RunCmd cmd)
        {
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }
    }
}
