using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.GnuGppWSL
{
    public class GnuGppWSL : BaseCmdProgram
    {
        // Distro name of WSL like 'Ubuntu'
        public static string DistroName = "";

        public async Task<BuildResult> BuildAsync(List<string> sources, string outputFilename = "")
        {
            SetupProgramPaths();

            BuildCmd cmd = new BuildCmd();
            cmd.Sources = sources;
            cmd.OutputFilename = outputFilename;
            var result = await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<BuildResult> BuildAsync(BuildCmd cmd)
        {
            SetupProgramPaths();

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
            SetupProgramPaths();

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
            SetupProgramPaths();

            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            DistroName = Config.BuildersSettings.GnuGpp.wsl_distro_name;
        }
    }
}
