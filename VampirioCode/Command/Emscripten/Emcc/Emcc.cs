using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emcc.Result;

namespace VampirioCode.Command.Emscripten.Emcc
{
    /// <summary>
    /// https://emscripten.org/docs/tools_reference/emcc.html?highlight=preload
    /// </summary>
    public class Emcc : BaseCmdProgram
    {

        public static string HelperProgramDirPath = "tools\\builders\\emscripten";
        public static string HelperProgramPath =    AppInfo.BasePath + HelperProgramDirPath + "\\emcc_build.bat";

        /// <summary>
        /// Get the version number
        /// </summary>
        /// <returns></returns>
        public async Task<VersionResult> VersionAsync()
        { 
            VersionCmd cmd =    new VersionCmd();
            var result =        await cmd.VersionAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Get the help
        /// </summary>
        /// <returns></returns>
        public async Task<HelpResult> HelpAsync()
        {
            HelpCmd cmd =       new HelpCmd();
            var result =        await cmd.VersionAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Build an application
        /// </summary>
        /// <param name="sourceFiles">Input source files like 'main.cpp'</param>
        /// <param name="outputFilename">Output filename like 'app.js'</param>
        /// <param name="exitRuntime"> If 0, the runtime is not quit when main() completes (allowing code to run afterwards, for example from the browser main event loop). atexit()s are also not executed, and we can avoid including code for runtime shutdown, like flushing the stdio streams. Set this to 1 if you do want atexit()s or stdio streams to be flushed on exit. This setting is controlled automatically in STANDALONE_WASM mode: - For a command (has a main function) this is always 1 - For a reactor (no a main function) this is always 0</param>
        /// <param name="embedFile">Embed a file like 'dir/file.txt' and then on c++ file.open('dir/file.txt');</param>
        /// <returns></returns>
        public async Task<BuildResult> BuildAsync(List<string> sourceFiles, string outputFilename, bool? exitRuntime = null, string embedFile = "")
        { 
            BuildCmd cmd =              new BuildCmd();
            cmd.SourceFiles =           sourceFiles;
            cmd.OutputFilename =        outputFilename;
            cmd.Options.ExitRuntime =   exitRuntime;
            cmd.EmbedFile =             embedFile;

            var result =                await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }
    }
}
