using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VampirioCode.Command.GnuGppWSL;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.UI;

namespace VampirioCode.Builder.Simple
{
    public class SimpleGnuCppWSLBuilder : Builder
    {
        private string objsDir;
        private string outputDir;

        public SimpleGnuCppWSLBuilder()
        {
            Name = "GNU g++";
            Type = BuilderType.SimpleGnuGppCpp;
        }

        public override void Prepare()
        {
            TempDir = AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir = TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile = ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_build\proj_name\proj.cpp
            objsDir = ProjectDir + "obj\\";               // output binaries dir ->   \temp_build\proj_name\obj\
            outputDir = ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\bin\
            OutputFilename = outputDir + projectName;            // output binaries dir ->   \temp_build\proj_name\bin\proj
        }

        protected override async Task OnBuildAndRun()
        {
            var result = await _Build();
            RunResult runResult;

            if (result.IsOk)
            {
                XConsole.Clear();
                GnuGppWSL msvc = new GnuGppWSL();
                runResult = await msvc.RunAsync(result.OutputFilename);
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

            // if '\temp_build' dir does not exist, just create it for the first time
            //if (!Directory.Exists(TempDir))
            //    Directory.CreateDirectory(TempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            //if (!Directory.Exists(ProjectDir))
            //    Directory.CreateDirectory(ProjectDir);

            CreateProjectStructure();

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
            List<string> sourceFiles = new string[] { GnuGppWSL.ToRelativePath(ProgramFile) }.ToList();


            GnuGppWSL msvc = new GnuGppWSL();
            var result = await msvc.BuildAsync(sourceFiles, GnuGppWSL.ToRelativePath(OutputFilename));
            result.OutputFilename = GnuGppWSL.ToRelativePath(OutputFilename);

            return result;
        }


    }
}
