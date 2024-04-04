using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.JDK;
using VampirioCode.Command.JDK.Result;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class SimpleJavaBuilder : Builder
    {
        //private string objsDir;
        private string outputDir;
        private string className;

        public SimpleJavaBuilder()
        {
            Name = "Javac";
            Type = BuilderType.SimpleJava;
        }

        public override void Prepare()
        {
            className =      GetClassName(code);

            if (className == "")
                className = projectName; // set this to get less errors if files needs to be deleted on the future maybe

            TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + className + ".java";   // .cpp program file ->     \temp_build\proj_name\className.java
            //objsDir =               ProjectDir + "obj\\";             // output binaries dir ->   \temp_build\proj_name\obj\
            outputDir =             ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\bin\
            OutputFilename =        outputDir + className + ".class";   // output binaries dir ->   \temp_build\proj_name\bin\proj.class
        }

        protected override async Task OnBuildAndRun()
        {
            var result = await _Build();
            RunResult runResult;

            if (result.IsOk)
            {
                XConsole.Clear();
                Java java = new Java();
                //runResult = await java.RunAsync(result.OutputFilename, new List<string>() { _fixLastEscapeBar(outputDir) });
                runResult = await java.RunAsync(className, new List<string>() {_quotes(_fixLastEscapeBar(outputDir)) });
                //return runResult;
            }

            runResult = new RunResult();
            runResult.SetError(result.ErrorInfo);
            //return runResult;
            CheckResult(result);
        }

        private async Task<BuildResult> _Build()
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

            Javac javac = new Javac();
            var result = await javac.BuildAsync(sourceFiles, _fixLastEscapeBar(outputDir));
            result.OutputFilename = OutputFilename;

            return result;
        }

        private string GetClassName(string code)
        {
            string[] searchs = new string[] { "public class ", "public  class ", "public   class " };
            int index;
            int curlyBracketIndex;
            string className = "";

            foreach (var search in searchs)
            {
                index = code.IndexOf(search);

                if (index != -1)
                {
                    index += search.Length;
                    curlyBracketIndex = code.IndexOf("{", index);
                    className = code.Substring(index, curlyBracketIndex - index).Trim();

                    break;
                }
            }

            return className;
        }
    }
}
