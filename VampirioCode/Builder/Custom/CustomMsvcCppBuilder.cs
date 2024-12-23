using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.CppSettings;
using VampirioCode.BuilderSetting.CppSettings.Settings;
using VampirioCode.BuilderSetting.Others;
using VampirioCode.Command.MSVC;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.Command.MSVC.Result;
using VampirioCode.Environment;
using VampirioCode.UI;
using VampirioCode.Utils;
using VampirioCode.Workspace;
using VampirioCode.Workspace.cpp;

namespace VampirioCode.Builder.Custom
{
    public class CustomMsvcCppBuilder : CustomBuilder
    {
        public MsvcCppBSetting Setting { get; set; }
        public CppWorkspace Workspace { get; set; }

        private List<string> includes =     new List<string>();
        private List<string> libPaths =     new List<string>();
        private List<string> libFiles =     new List<string>();

        private string objsDir;
        private string outputDir;

        public CustomMsvcCppBuilder()
        {
            Name = "CustomMsvc";
            Type = BuilderType.CustomMsvcCpp;

            Setting =   new MsvcCppBSetting();
            Workspace = new CppWorkspace();

        }

        public override void Prepare()
        {
            //XConsole.Alert("test: " + originalBaseDirPath);
            //TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            TempDir =               originalBaseDirPath + "\\" + AppInfo.VampTempDir + "\\";         // temporary directory ->   \temp_proj\_vamp\

            //XConsole.Alert("TempDir: " + TempDir);

            //Directory.CreateDirectory(TempDir);

            BaseProjDir =           TempDir + projectName + "\\";       // temporary base dir ->    \temp_proj\_vamp\proj_name\
            BuilderTypeDir =        BaseProjDir + "msvc\\";             // temp builder type dir -> \temp_proj\_vamp\proj_name\msvc\
            ProjectDir =            BuilderTypeDir + "build\\";         // temporary project dir -> \temp_proj\_vamp\proj_name\msvc\build\
            ProgramFile =           ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_proj\_vamp\proj_name\msvc\build\proj.cpp
            objsDir =               ProjectDir + "obj\\";               // output binaries dir ->   \temp_proj\_vamp\proj_name\msvc\build\obj\
            outputDir =             ProjectDir + "bin\\";               // output binaries dir ->   \temp_proj\_vamp\proj_name\msvc\build\bin\
            OutputFilename =        outputDir + projectName + ".exe";   // output binaries dir ->   \temp_proj\_vamp\proj_name\msvc\build\bin\proj.exe

            // Custom Build Settings File
            WorkspaceFile =         TempDir +        AppInfo.WorkspaceFileName;      // build workspace file ->  \temp_proj\_vamp\.workspace
            BuildSettingsFile =     BuilderTypeDir + AppInfo.BSettingsFileName;      // build settings file ->   \temp_proj\_vamp\proj_name\msvc\.bsettings
            //BuildSettingsFile =     ProjectDir + ".bsettings";          // build settings file ->     \temp_build\proj_name\msvc\.bsettings
            //BuildSettingsFile = originalBaseDir + ".bsettings";
            //BuildSettingsFile = originalBaseDirPath + "\\v" + originalBaseDirName + "\\msvc\\" + ".bsettings";
            
            
            //XConsole.Alert("TempDir: " + TempDir);
            //XConsole.Alert("BuildSettingsFile: " + BuildSettingsFile);
            
            
            //XConsole.Alert("originalBaseDirPath: " + originalBaseDirPath);

        }

        protected override void OnSave()
        {
            // Settings '.bsetting'
            SaveSetting<MsvcCppBSetting>(Setting);

            // Workspace
            Workspace.MainFile =                Path.GetRelativePath(originalBaseDirPath, originalFullFilePath);
            //Workspace.MsvcProject =             new WorkspaceProject();
            //Workspace.MsvcProject.MainFile =    Workspace.MainFile;//Path.GetRelativePath(BaseProjDir, ProgramFile);
            //Workspace.MsvcProject.BuilderType = Type;
            Workspace.DefaultBuilderType =      BuilderType.CustomMsvcCpp;

            SaveWorkspace<CppWorkspace>(Workspace);
        }

        protected override void OnLoad()
        {
            //XConsole.Alert("on load: " + BuildSettingsFile);
            //PrintStackTrace();
            Setting =   LoadSetting<MsvcCppBSetting>();
            Workspace = LoadWorkspace<CppWorkspace>();

            // Change file extension. e.g: 'proj.exe' to 'proj.dll' or 'proj.lib'
            OutputFilename = ConvertOutputFilename(OutputFilename, Setting.OutputType);
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
                if (Setting.OutputType == OutputType.Executable)
                {
                    XConsole.Clear();
                    MSVC msvc = new MSVC();
                    runResult = await msvc.RunAsync(result.OutputFilename);
                    //return runResult;
                }
                else
                {
                    XConsole.Clear();
                    XConsole.LogInfo("The file '" + Path.GetFileName(result.OutputFilename) + "' is not an executable.");
                }
            }

            runResult = new RunResult();
            runResult.SetError(result.ErrorInfo);
            //return runResult;
            CheckResult(result);
        }


        private async Task<BuildResult> _Build()
        {
            Prepare();
            Load();

            // if '\temp_build' dir does not exist, just create it for the first time
            //if (!Directory.Exists(TempDir))
            //    Directory.CreateDirectory(TempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            //if (!Directory.Exists(ProjectDir))
            //    Directory.CreateDirectory(ProjectDir);

            CreateProjectStructure();

            // Find main entry point "int main(...)"
            //FindMainEntryPoint(Setting, BaseProjDir);

            // if '\temp_build\proj_name\obj' dir does not exist, just create it for the first time
            if (!Directory.Exists(objsDir))
                Directory.CreateDirectory(objsDir);

            // if '\temp_build\proj_name\bin' dir does not exist, just create it for the first time
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);


            // [ COMPILATION PROCESS ]
            List<string> sourceFiles;
            string[] dontInclude = null;


            if (IsOutputLibrary())
                dontInclude = new string[] { originalFileName };

            if (Setting.IncludeSourcesMode == IncludeSourcesMode.Automatic)
            { 
                sourceFiles = await CopySourceFilesAsync(null, new string[] { ".cpp", ".h" }, dontInclude);
            }
            else if(Setting.IncludeSourcesMode == IncludeSourcesMode.Manually)
            {
                sourceFiles = await CopySourceFilesAsync(Setting.SourceFiles, new string[] { ".cpp", ".h" }, dontInclude);
            }
            else // Default
            {
                sourceFiles = new string[] { ProgramFile }.ToList();

                // write all code to '\temp_build\proj_name\msvc\proj.cpp' main program file
                File.WriteAllText(ProgramFile, code);
            }

            

            //XConsole.Alert("STOP");
            
            // Build Process
            MSVC msvc = new MSVC();
            
            BuildCmd cmd = new BuildCmd();
            //BuildHelper.AddBasicVars(this);
            cmd.AddVariable(Variables.ProjDir,  ProjectDir);
            cmd.Sources =                       sourceFiles;
            cmd.OutputFilename =                OutputFilename;
            cmd.OutputObjsDir =                 objsDir;
            cmd.PreprocessorDefinitions =       VariableAction.ToString(Setting.PreprocessorMacros, "=");
            cmd.Includes =                      Setting.IncludeDirs;
            cmd.LibraryPaths =                  Setting.LibraryDirs;
            cmd.LibraryFiles =                  Setting.LibraryFiles;

            cmd.OutputType =                    Setting.OutputType;
            cmd.StandardVersion =               Setting.StandardVersion;
            cmd.ExceptionHandlingModel =        Setting.ExceptionHanldingModel;
            
            if (Setting.InstallPackage != "")
            {
                await ImportPackage(Setting.InstallPackage, ProjectDir);
            }
            
            
            bool copied;
            copied = await CopyDirs(Setting.CopyDirsPost, cmd);
            if (!copied) XConsole.Alert("error");

            copied = await CopyFiles(Setting.CopyFilesPost, cmd);
            if (!copied) XConsole.Alert("error");

            if (Setting.OutputType == OutputType.DynamicLib)
            {
                //XConsole.Alert("enter: " + Path.ChangeExtension(cmd.OutputFilename, ".lib"));
                cmd.OutputLibraryDir = Path.ChangeExtension(cmd.OutputFilename, ".lib");
            }


            //var result = await msvc.BuildAsync(sourceFiles, OutputFilename, objsDir, Setting.IncludeDirs, Setting.LibraryDirs, Setting.LibraryFiles);
            var result = await msvc.BuildAsync(cmd);
            result.OutputFilename = cmd.OutputFilename;

            // ---------------------------------
            //          Library Build
            // ---------------------------------
            if (CheckResult(result) && (cmd.OutputType == OutputType.StaticLib))
            {
                XConsole.Alert(OutputFilename);
                var objFiles = await GetObjFiles();

                BuildLibCmd libCmd =        new BuildLibCmd();
                libCmd.ObjectFiles =        objFiles;
                libCmd.LibOutputFilename =  cmd.OutputFilename;

                var libResult = await msvc.BuildLibAsync(libCmd);
                libResult.LibOutputFilename =   libCmd.LibOutputFilename;
                result.OutputFilename =         libResult.LibOutputFilename;
            }

            return result;
        }

        private Task<List<string>> GetObjFiles()
        {
            return FileUtils.GetFilesAdvAsync(objsDir, new string[] { ".obj" }, null, true, true);
        }

        private bool IsOutputLibrary()
        {
            return ((Setting.OutputType == OutputType.StaticLib) || (Setting.OutputType == OutputType.DynamicLib));
        }

        private string ConvertOutputFilename(string fullFileName, OutputType type)
        {
            if (type == OutputType.Executable)
                return Path.ChangeExtension(fullFileName, ".exe");
            else if (type == OutputType.DynamicLib)
                return Path.ChangeExtension(fullFileName, ".dll");
            else //if (type == OutputType.Static)
                return Path.ChangeExtension(fullFileName, ".lib");
        }

    }
}
