using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.CppSettings.Settings;
using VampirioCode.Command.MSVC;
using VampirioCode.Command.MSVC.Result;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode.Builder.Custom
{
    public class CustomMsvcCppBuilder : CustomBuilder
    {
        public MsvcCppBSetting Setting { get; set; }

        private List<string> includes =     new List<string>();
        private List<string> libPaths =     new List<string>();
        private List<string> libFiles =     new List<string>();

        private string objsDir;
        private string outputDir;

        public CustomMsvcCppBuilder()
        {
            Name = "CustomMsvc";
            Type = BuilderType.SimpleMsvcCpp;

            Setting = new MsvcCppBSetting();
        }

        public override void Prepare()
        {
            TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_build\proj_name\proj.cpp
            objsDir =               ProjectDir + "obj\\";               // output binaries dir ->   \temp_build\proj_name\obj\
            outputDir =             ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\bin\
            OutputFilename =        outputDir + projectName + ".exe";   // output binaries dir ->   \temp_build\proj_name\bin\proj.exe

            // Custom Build Settings File
            BuildSettingsFile =     ProjectDir + ".bsettings";        // build settings file ->   \temp_build\proj_name\.bsettings
        }

        protected override void OnSave()
        {
            SaveSetting<MsvcCppBSetting>(Setting);
        }

        protected override void OnLoad()
        {
            //XConsole.Alert("on load: " + BuildSettingsFile);
            //PrintStackTrace();
            Setting = LoadSetting<MsvcCppBSetting>();
        }

        /*static void PrintStackTrace()
        {
            StackTrace stackTrace = new StackTrace(true);
            string stackTraceString = "Stack trace:\n";

            foreach (StackFrame frame in stackTrace.GetFrames())
            {
                string fileName = frame.GetFileName();
                if (fileName != null)
                {
                    fileName = Path.GetFileName(fileName);
                }
                else
                {
                    fileName = "Unknown file";
                }

                string method = frame.GetMethod().Name;
                int lineNumber = frame.GetFileLineNumber();

                if(lineNumber > 0)
                    stackTraceString += $"{fileName}::{method} (Line {lineNumber})\n";
            }

            XConsole.Alert(stackTraceString);
        }*/

        protected override async Task OnBuildAndRun()
        {
            var result = await _Build();
            RunResult runResult;

            if (result.IsOk)
            {
                XConsole.Clear();
                MSVC msvc = new MSVC();
                runResult = await msvc.RunAsync(result.OutputFilename);
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

            // Build Process
            MSVC msvc = new MSVC();

            BuildCmd cmd = new BuildCmd();
            //BuildHelper.AddBasicVars(this);
            cmd.AddVariable("${projDir}",   ProjectDir);
            cmd.Sources =                   sourceFiles;
            cmd.OutputFilename =            OutputFilename;
            //cmd.OutputObjsDir =             objsDir;
            cmd.PreprocessorDefinitions =   VariableAction.ToString(Setting.PreprocessorMacros, "=");
            cmd.Includes =                  Setting.IncludeDirs;
            cmd.LibraryPaths =              Setting.LibraryDirs;
            cmd.LibraryFiles =              Setting.LibraryFiles;

            cmd.StandardVersion =           Setting.StandardVersion;
            
            if (Setting.InstallPackage != "")
            {
                await ImportPackage(Setting.InstallPackage, ProjectDir);
            }
            
            
            bool copied;
            copied = await CopyDirs(Setting.CopyDirsPost, cmd);
            if (!copied) XConsole.Alert("error");

            copied = await CopyFiles(Setting.CopyFilesPost, cmd);
            if (!copied) XConsole.Alert("error");

            //var result = await msvc.BuildAsync(sourceFiles, OutputFilename, objsDir, Setting.IncludeDirs, Setting.LibraryDirs, Setting.LibraryFiles);
            var result = await msvc.BuildAsync(cmd);
            result.OutputFilename = OutputFilename;

            return result;
        }

    }
}
