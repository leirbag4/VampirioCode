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
        /// Run the compiled executable '.exe'
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

        // This fixes an issue with WSL where you can't use absolute paths
        // [DOESN'T WORK]:  wsl -d Ubuntu-test g++ "C:\tests\capitan\untitled 1.cpp"
        // [DOESN'T WORK]:  wsl -d Ubuntu-test g++ "C:/tests/capitan/untitled 1.cpp"
        // [WORKS OK]:      wsl -d Ubuntu-test g++ "../capitan/untitled 1.cpp"
        public static string ToRelativePath(string absoluteFilePath)
        {
            return ("./" + Path.GetRelativePath(AppInfo.BasePath, absoluteFilePath)).Replace("\\", "/");
        }

    }
}
