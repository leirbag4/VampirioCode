// Just comment this define in case you don't need libclang.dll
#define USE_LIBCLANG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Clang;
using VampirioCode.Command.Clang.Result;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class SimpleClangCppBuilder : Builder
    {
        //private string objsDir;
        private string outputDir;

        public SimpleClangCppBuilder()
        {
            Name = "Clang++";
            Type = BuilderType.SimpleClangCpp;
        }

        public override void Prepare()
        {
            TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_build\proj_name\proj.cpp
            //objsDir =               ProjectDir + "obj\\";               // output binaries dir ->   \temp_build\proj_name\obj\
            outputDir =             ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\bin\
            OutputFilename =        outputDir + projectName + ".exe";   // output binaries dir ->   \temp_build\proj_name\bin\proj.exe
        }

        protected override async Task OnBuildAndRun()
        {
            var result = await _Build();
            RunResult runResult;

            if (result.IsOk)
            {
                XConsole.Clear();
                Clang clang = new Clang();
                
                List<string> libPaths = new List<string>();
#if USE_LIBCLANG                
                libPaths.Add(@"C:\programs_dev\clang_llvm_18_1_0\lib");
#endif
                runResult = await clang.RunAsync(result.OutputFilename, libPaths);
                //return runResult;
            }

            runResult = new RunResult();
            runResult.SetError(result.ErrorInfo);
            //return runResult;
            CheckResult(result);
        }


        public async Task<BuildResult> _Build()
        {
            Prepare();


            CreateProjectStructure();

            // if '\temp_build\proj_name\obj' dir does not exist, just create it for the first time
            //if (!Directory.Exists(objsDir))
            //    Directory.CreateDirectory(objsDir);

            // if '\temp_build\proj_name\bin' dir does not exist, just create it for the first time
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cpp' main program file
            File.WriteAllText(ProgramFile, code);


            // [ COMPILATION PROCESS ]
            List<string> sourceFiles = new string[] { ProgramFile }.ToList();

            List<string> includes = new List<string>();
            List<string> libPaths = new List<string>();
            List<string> libFiles = new List<string>();

#if USE_LIBCLANG
            includes.Add(@"C:\programs_dev\clang_llvm_18_1_0\include");
            libPaths.Add(@"C:\programs_dev\clang_llvm_18_1_0\lib");
            libFiles.Add("libclang.lib");
#endif

            Clang clang = new Clang();
            var result = await clang.BuildAsync(sourceFiles, OutputFilename, includes, libPaths, libFiles);
            result.OutputFilename = OutputFilename;

            return result;
        }

    }
}
