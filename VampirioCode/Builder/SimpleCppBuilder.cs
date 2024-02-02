using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.MSVC;
using VampirioCode.Command.MSVC.Result;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class SimpleCppBuilder : Builder
    {
        private string projectName;
        private string code = "";

        public void Setup(string projectName, string code)
        { 
            this.projectName =  projectName;
            this.code =         code;
        }

        public async Task<RunResult> BuildAndRun()
        {
            var result = await Build();
            RunResult runResult;

            if (result.IsOk)
            {
                XConsole.Clear();
                MSVC msvc = new MSVC();
                runResult = await msvc.RunAsync(result.OutputFilename);
                return runResult;
            }

            runResult = new RunResult();
            runResult.SetError(result.ErrorInfo);
            return runResult;
        }


        public async Task<BuildResult> Build()
        {
            string tempDir =        AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            string projDir =        tempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            string programFile =    projDir + projectName + ".cpp";     // .cpp program file ->     \temp_build\proj_name\proj.cpp
            string objsDir =        projDir + "obj\\";                  // output binaries dir ->   \temp_build\proj_name\obj\
            string outputDir =      projDir + "bin\\";                  // output binaries dir ->   \temp_build\proj_name\bin\
            string outputFilename = outputDir + projectName + ".exe";   // output binaries dir ->   \temp_build\proj_name\bin\proj.exe


            // if '\temp_build' dir does not exist, just create it for the first time
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            if (!Directory.Exists(projDir))
                Directory.CreateDirectory(projDir);

            // if '\temp_build\proj_name\obj' dir does not exist, just create it for the first time
            if (!Directory.Exists(objsDir))
                Directory.CreateDirectory(objsDir);

            // if '\temp_build\proj_name\bin' dir does not exist, just create it for the first time
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cpp' main program file
            File.WriteAllText(programFile, code);


            // [ COMPILATION PROCESS ]
            List<string> sourceFiles = new string[] { programFile }.ToList();

            List<string> includes = new string[] {
                @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.38.33130\include",
                @"C:\Program Files (x86)\Windows Kits\10\Include\10.0.22621.0\ucrt"
            }.ToList();

            List<string> libPaths = new string[] {
                @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.38.33130\lib\x64",
                @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\um\x64",
                @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\ucrt\x64"
            }.ToList();

            List<string> libFiles = new string[] {
                "libcpmt.lib",
                "kernel32.lib",
                "libucrt.lib"
            }.ToList();

            MSVC msvc = new MSVC();
            var result = await msvc.BuildAsync(sourceFiles, outputFilename, objsDir, includes, libPaths, libFiles);
            result.OutputFilename = outputFilename;

            return result;
        }
    }
}
