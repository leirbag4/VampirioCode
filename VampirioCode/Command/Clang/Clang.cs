using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Clang.Result;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.SaveData;

namespace VampirioCode.Command.Clang
{
    public class Clang : BaseCmdProgram
    {
        public static string ProgramPath = "";     //@"C:\programs_dev\clang_llvm_18_1_0\bin\clang++.exe";

        public async Task<BuildResult> BuildAsync(List<string> sources, string outputFilename = "", List<string> includes = null, List<string> libraryPaths = null, List<string> libraryFiles = null)
        {
            SetupProgramPaths();

            BuildCmd cmd = new BuildCmd();
            cmd.Sources =           sources;
            cmd.OutputFilename =    outputFilename;
            cmd.Includes =          includes;
            cmd.LibraryPaths =      libraryPaths;
            cmd.LibraryFiles =      libraryFiles;
            var result =            await cmd.BuildAsync();
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

        public async Task<RunResult> RunAsync(string filename, List<string> libraryPaths = null)
        {
            SetupProgramPaths();

            RunCmd cmd =        new RunCmd();
            cmd.Filename =      filename;
            cmd.LibraryPaths =  libraryPaths;
            var result =        await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            ProgramPath = Config.BuildersSettings.CLang.clang_exe_path;
        }
    }
}
