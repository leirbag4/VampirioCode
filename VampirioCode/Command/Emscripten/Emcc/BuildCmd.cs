using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emcc.Params;
using VampirioCode.Command.Emscripten.Emcc.Result;
using VampirioCode.Properties;
using VampirioCode.UI;

namespace VampirioCode.Command.Emscripten.Emcc
{
    //
    // INFO: https://github.com/emscripten-core/emscripten/blob/main/src/settings.js
    //

    // Settings that control the emscripten compiler.  These are available to the
    // python code and also as global variables when the JS compiler runs. They
    // are set via the command line.  For example:
    //
    //   emcc -sOPTION1=VALUE1 -sOPTION2=ITEM1,ITEM2 [..other stuff..]
    //
    // For convenience and readability ``-sOPTION`` expands to ``-sOPTION=1``
    // and ``-sNO_OPTION`` expands to ``-sOPTION=0`` (assuming OPTION is a valid
    // option).
    //
    // See https://github.com/emscripten-core/emscripten/wiki/Code-Generation-Modes/
    //
    // Note that the values here are the defaults which can be affected either
    // directly via ``-s`` flags or indirectly via other options (e.g. -O1,2,3)
    //
    // These flags should only have an effect when compiling to JS, so there
    // should not be a need to have them when just compiling source to
    // bitcode. However, there will also be no harm either, so it is ok to.
    //
    // Settings in this file can be directly set from the command line.  Internal
    // settings that are not part of the user ABI live in the settings_internal.js.
    //
    // In general it is best to pass the same arguments at both compile and link
    // time, as whether wasm object files are used or not affects when codegen
    // happens (without wasm object files, codegen is done entirely during
    // link; otherwise, it is during compile). Flags affecting codegen must
    // be passed when codegen happens, so to let a build easily switch when codegen
    // happens (LTO vs normal), pass the flags at both times. The flags are also
    // annotated in this file:
    //
    // [link] - Should be passed at link time. This is the case for all JS flags,
    //          as we emit JS at link (and that is most of the flags here, and
    //          hence the default).
    // [compile+link] - A flag that has an effect at both compile and link time,
    //                  basically any time emcc is invoked. The same flag should be
    //                  passed at both times in most cases.
    //
    // If not otherwise specified, a flag is [link]. Note that no flag is only
    // relevant during compile time, as during link we may do codegen for system
    // libraries and other support code, so all flags are either link or
    // compile+link.
    //
    public class BuildCmd : BaseCmd
    {

        /// <summary>
        /// Options from https://github.com/emscripten-core/emscripten/blob/main/src/settings.js
        /// </summary>
        public Options Options = new Options();

        /// <summary>
        /// Main source input files like main.cpp
        /// </summary>
        public List<string> SourceFiles = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public string EmbedFile = "";


        public string OutputFilename = "";

        public async Task<BuildResult> BuildAsync()
        {
            // We must first activate 'emsdk' with -> 'emsdk activate latest'
            // Then we can call emcc like -> 'emcc main.cpp -o app.js'
            // And because we need to call these 2 programs at the same time
            // we will use a helper batch called 'emcc_build.bat' that will be
            // created here if it does not exist

            // emsdk
            Set(Emsdk.Emsdk.ProgramPath);
            Set("activate");
            Set("latest");

            // emcc
            Set("emcc");
            SetIfExists(Options.Create());
            SetIfExists(SourceFiles.ToArray());
            SetIfExists("--embed-file", EmbedFile);
            SetIfExists("-o",           OutputFilename);
            AutoTriggerErrors = false;
            //return await CreateCommand<BuildResult>("emcc", cmd.Trim());

            // Create helper batch file -> 'emcc_build.bat'
            CreateBuildHelper();
            return await CreateCommand<BuildResult>(Emcc.HelperProgramPath, cmd.Trim());
        }

        /// <summary>
        /// [More efficient and faster version]
        /// Use this version of Build only if 'emsdk activate latest --permanent' was called before to set
        /// the environment variables. Otherwise 'emcc' won't be found.
        /// </summary>
        /// <returns></returns>
        public async Task<BuildResult> BuildWithPrevPermanentAsync()
        {
            SetIfExists(Options.Create());
            SetIfExists(SourceFiles.ToArray());
            SetIfExists("--embed-file", EmbedFile);
            SetIfExists("-o", OutputFilename);
            AutoTriggerErrors = false;
            return await CreateCommand<BuildResult>("emcc", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            // errors are not errors here
            Println(data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }


        // This file is a helper file because you need first to launch 'emsdk.bat activate latest'
        // which sets all environment variables like the needed for python, nodejs and also fill PATH.
        // And after that you can run emcc.exe but you can't create 2 different Process() because
        // environment variables are deleted from context to context.So here you do the 2 things
        // at once, first call emsdk to set environment variables and the call the emcc compiler.
        private void CreateBuildHelper()
        {
            string batFileContent = @":: This file is a helper file because you need first to launch 'emsdk.bat activate latest'
:: which sets all environment variables like the needed for python, nodejs and also fill PATH.
:: And after that you can run emcc.exe but you can't create 2 different Process() because
:: environment variables are deleted from context to context. So here you do the 2 things 
:: at once, first call emsdk to set environment variables and the call the emcc compiler.
@echo off
setlocal enabledelayedexpansion

set EMSDK_CMD=%1
set EMSDK_PARAM0=%2
set EMSDK_PARAM1=%3
set EMCC_CMD=%4


set ""EMCC_PARAMS=""
set ""COUNT=0""

REM Ignoramos los primeros tres parámetros
for %%i in (%*) do (
    set /a ""COUNT+=1""
    if !COUNT! gtr 4 (
        set ""EMCC_PARAMS=!EMCC_PARAMS! %%i""
    )
)

set EMSDK_BIN=%EMSDK_CMD% %EMSDK_PARAM0% %EMSDK_PARAM1%
set EMCC_BIN=%EMCC_CMD%%EMCC_PARAMS%

echo  ------------------------------
echo  Util and helper tool for emcc
echo  ------------------------------
echo.
echo emsdk path: %EMSDK_CMD%
echo emsdk param0: %EMSDK_PARAM0%
echo emsdk param1: %EMSDK_PARAM1%
echo emcc path: %EMCC_CMD%
echo emcc params: %EMCC_PARAMS%

echo.
echo calling emsdk: %EMSDK_BIN%
echo.
call %EMSDK_BIN%

echo.
echo calling emcc: %EMCC_BIN%
call %EMCC_BIN%

endlocal";

            if (!Directory.Exists(Emcc.HelperProgramDirPath))
            {
                try
                {
                    Directory.CreateDirectory(Emcc.HelperProgramDirPath);
                }
                catch (Exception e)
                {
                    CallError("Can't directories for emcc's helper file: " + Emcc.HelperProgramDirPath, e);
                }
            }

            if (!File.Exists(Emcc.HelperProgramPath))
            {
                try
                {
                    File.WriteAllText(Emcc.HelperProgramPath, batFileContent);
                }
                catch (Exception e)
                {
                    CallError("Can't create emcc helper bat file", e);
                }
            }

        }



    }
}
