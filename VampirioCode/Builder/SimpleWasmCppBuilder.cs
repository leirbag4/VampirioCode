using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emcc;
using VampirioCode.Command.Emscripten.Emcc.Result;
using VampirioCode.Command.Emscripten.Emsdk;
using VampirioCode.Command.Nodejs;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class SimpleWasmCppBuilder : Builder
    {

        private string objsDir;
        private string outputDir;

        public override void Prepare()
        {
            TempDir =           AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =        TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =       ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_build\proj_name\proj.cpp
            objsDir =           ProjectDir + "obj\\";               // output binaries dir ->   \temp_build\proj_name\obj\
            outputDir =         ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\bin\
            OutputFilename =    outputDir + projectName + ".js";    // output binaries dir ->   \temp_build\proj_name\bin\proj.js
        }

        protected override async Task OnBuildAndRun()
        {
            Prepare();

            // if '\temp_build' dir does not exist, just create it for the first time
            if (!Directory.Exists(TempDir))
                Directory.CreateDirectory(TempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            if (!Directory.Exists(ProjectDir))
                Directory.CreateDirectory(ProjectDir);

            // if '\temp_build\proj_name\obj' dir does not exist, just create it for the first time
            if (!Directory.Exists(objsDir))
                Directory.CreateDirectory(objsDir);

            // if '\temp_build\proj_name\bin' dir does not exist, just create it for the first time
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cpp' main program file
            File.WriteAllText(ProgramFile, code);


            // [ COMPILATION PROCESS ]
            List<string> sourceFiles = new string[] { ProgramFile }.ToList();

            Emcc emcc = new Emcc();
            var result = await emcc.BuildAsync(sourceFiles, OutputFilename, true);

            CheckResult(result);

            if (result.IsOk)
            {
                XConsole.Clear();
                Nodejs nodejs = new Nodejs();
                var newResult = await nodejs.RunAsync(OutputFilename);
            }
        }

    }
}
