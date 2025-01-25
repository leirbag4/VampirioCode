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
using VampirioCode.Command;
using VampirioCode.Command.GnuGppWSL;
using VampirioCode.Command.GnuGppWSL.Params;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.Environment;
using VampirioCode.UI;
using VampirioCode.Utils;
using VampirioCode.Workspace.cpp;

namespace VampirioCode.Builder.Custom
{
    public class CustomGnuCppWSLBuilder : CustomBuilder
    {
        public GnuCppBSetting Setting { get; set; }
        public CppWorkspace Workspace { get; set; }

        private List<string> includes =     new List<string>();
        private List<string> libPaths =     new List<string>();
        private List<string> libFiles =     new List<string>();

        private string objsDir;

        public CustomGnuCppWSLBuilder()
        {
            Name =          "CustomGnuCppWSL";
            Type =          BuilderType.CustomGnuGppWSLCpp;
            BuilderKind =   BuilderKind.CppGnuGpp;

            Setting = new GnuCppBSetting();
            Workspace = new CppWorkspace();
        }

        public override void Prepare()
        {
            /*TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            BaseProjDir =           TempDir + projectName + "\\";       // temporary base dir ->    \temp_build\proj_name\
            ProjectDir =            BaseProjDir + "gnuCppWsl\\";        // temporary project dir -> \temp_build\proj_name\CppGnuGpp\
            ProgramFile =           ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_build\proj_name\CppGnuGpp\proj.cpp
            objsDir =               ProjectDir + "obj\\";               // output binaries dir ->   \temp_build\proj_name\CppGnuGpp\obj\
            outputDir =             ProjectDir + "bin\\";               // output binaries dir ->   \temp_build\proj_name\CppGnuGpp\bin\
            OutputFilename =        outputDir + projectName;            // output binaries dir ->   \temp_build\proj_name\CppGnuGpp\bin\proj

            // Custom Build Settings File
            BuildSettingsFile =     ProjectDir + ".bsettings";        // build settings file ->   \temp_build\proj_name\CppGnuGpp\.bsettings
            */

            TempDir = originalBaseDirPath + "\\" + AppInfo.VampTempDir + "\\";         // temporary directory ->   \temp_proj\_vamp\

            BaseProjDir =       TempDir + projectName + "\\";       // temporary base dir ->    \temp_proj\_vamp\proj_name\
            BuilderTypeDir =    BaseProjDir + BuilderKind + "\\";   // temp builder type dir -> \temp_proj\_vamp\proj_name\CppGnuGpp\
            ProjectDir =        BuilderTypeDir + "build\\";         // temporary project dir -> \temp_proj\_vamp\proj_name\CppGnuGpp\build\
            ProgramFile =       ProjectDir + projectName + ".cpp";  // .cpp program file ->     \temp_proj\_vamp\proj_name\CppGnuGpp\build\proj.cpp
            objsDir =           ProjectDir + "obj\\";               // output binaries dir ->   \temp_proj\_vamp\proj_name\CppGnuGpp\build\obj\
            outputDir =         ProjectDir + "bin\\";               // output binaries dir ->   \temp_proj\_vamp\proj_name\CppGnuGpp\build\bin\
            OutputFilename =    outputDir + projectName;            // output binaries dir ->   \temp_proj\_vamp\proj_name\CppGnuGpp\build\bin\proj.exe

            // Custom Build Settings File
            WorkspaceFile = TempDir + AppInfo.WorkspaceFileName;      // build workspace file ->  \temp_proj\_vamp\.workspace
            BuildSettingsFile = BuilderTypeDir + AppInfo.BSettingsFileName;      // build settings file ->   \temp_proj\_vamp\proj_name\CppGnuGpp\.bsettings

        }

        protected override void OnSave()
        {
            SaveSetting<GnuCppBSetting>(Setting);

            // Workspace
            Workspace.MainFile =            Path.GetRelativePath(originalBaseDirPath, originalFullFilePath);
            Workspace.DefaultBuilderType =  BuilderType.CustomGnuGppWSLCpp;
            Workspace.RegisterProject(Type, BuilderKind);

            SaveWorkspace<CppWorkspace>(Workspace);
        }

        protected override void OnLoad()
        {
            //XConsole.Alert("on load: " + BuildSettingsFile);
            //PrintStackTrace();
            Setting =   LoadSetting<GnuCppBSetting>();
            Workspace = LoadWorkspace<CppWorkspace>();

            // Change file extension. e.g: 'proj.exe' to 'proj.dll' or 'proj.lib'
            OutputFilename = ConvertOutputFilename(OutputFilename, Setting.OutputType);
        }


        protected override async Task OnBuildAndRun()
        {
            var result = await _Build();
            RunResult runResult;

            if (result.IsOk)
            {
                if (Setting.OutputType == OutputType.Executable)
                {
                    XConsole.Clear();
                    GnuGppWSL gnuGppWSL = new GnuGppWSL();

                    RunCmd runCmd = new RunCmd();
                    runCmd.AddVariable(Variables.ProjDir, ProjectDir);

                    if (Setting.LibraryDirs.Count > 0)
                        runCmd.LibraryPaths = Setting.LibraryDirs;

                    runCmd.Filename = result.OutputFilename;
                    runResult = await gnuGppWSL.RunAsync(runCmd);
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

            CreateProjectStructure();

            // if '\temp_build\proj_name\obj' dir does not exist, just create it for the first time
            if (!Directory.Exists(objsDir))
                Directory.CreateDirectory(objsDir);

            // if '\temp_build\proj_name\bin' dir does not exist, just create it for the first time
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);
            //XConsole.Alert(originalFullFilePath);
            //XConsole.Alert(originalBaseDir);

            //FileUtils.GetFilesAt

            // write all code to '\temp_build\proj_name\proj.cpp' main program file
            //File.WriteAllText(ProgramFile, code);


            // [ COMPILATION PROCESS ]
            //List<string> sourceFiles = new string[] { ProgramFile }.ToList();
            //List<string> sourceFiles = new string[] { CmdUtils.ToUnixRelativePath(ProgramFile) }.ToList();

            List<string> sourceFiles = null;
            string[] dontInclude = null;

            if (Setting.IncludeSourcesMode == IncludeSourcesMode.Automatic)
            {

                File.WriteAllText(ProgramFile, code);
                sourceFiles = await CopySourceFilesAsync(null, new string[] { ".cpp", ".h" }, dontInclude);
                sourceFiles.Insert(0, ProgramFile);

                // Remove repeated sources
                sourceFiles = sourceFiles.Distinct().ToList();
                sourceFiles = CmdUtils.ToUnixRelativePaths(sourceFiles);

            }
            else if (Setting.IncludeSourcesMode == IncludeSourcesMode.Manually)
            {
                //dontInclude = new string[] { originalFileName };

                List<string> newSourceFiles = GetManuallySettingsSources(Setting.SourceFiles);

                sourceFiles = await CopySourceFilesAsync(newSourceFiles, new string[] { ".cpp", ".h" }, dontInclude);
                sourceFiles.Insert(0, ProgramFile);

                // Remove repeated sources
                sourceFiles = sourceFiles.Distinct().ToList();
                sourceFiles = CmdUtils.ToUnixRelativePaths(sourceFiles);

                //XConsole.Alert("stop here");
            }
            else // Default
            {
                sourceFiles = new string[] { ProgramFile }.ToList();
                sourceFiles = CmdUtils.ToUnixRelativePaths(sourceFiles);

                // write all code to '\temp_build\proj_name\CppGnuGpp\proj.cpp' main program file
                File.WriteAllText(ProgramFile, code);
            }




            // Build Process
            GnuGppWSL gnuGppWSL = new GnuGppWSL();

            BuildCmd cmd = new BuildCmd();
            //BuildHelper.AddBasicVars(this);
            cmd.AddVariable(Variables.ProjDir,  ProjectDir);
            cmd.Sources =                       sourceFiles;

            /*foreach (string obj in cmd.OutputObjFiles) 
            {
                XConsole.Alert("IS: " + obj);
            }*/

            if (IsStaticLib())
            { 
                //cmd.OutputObjFiles =            CmdUtils.ToUnixRelativePaths(ToObjFiles(sourceFiles));
            }
            else
                cmd.OutputFilename =            CmdUtils.ToUnixRelativePath(OutputFilename);
            //cmd.OutputObjsDir =                 objsDir;
            cmd.PreprocessorDefinitions =       VariableAction.ToString(Setting.PreprocessorMacros, "=");
            cmd.Includes =                      Setting.IncludeDirs;
            cmd.LibraryPaths =                  Setting.LibraryDirs;
            cmd.LibraryFiles =                  Setting.LibraryFiles;

            cmd.OutputType =                    Setting.OutputType;
            cmd.StandardVersion =               Setting.StandardVersion;
            
            if (Setting.InstallPackages.Count > 0)
                await ImportPackages(Setting.InstallPackages, ProjectDir);

            // Copy 'res' directory if exists
            await CopyResDir();

            bool copied;
            copied = await CopyDirs(Setting.CopyDirsPost, cmd);
            if (!copied) XConsole.Alert("error");

            copied = await CopyFiles(Setting.CopyFilesPost, cmd);
            if (!copied) XConsole.Alert("error");


            var result = await gnuGppWSL.BuildAsync(cmd);
            result.OutputFilename = CmdUtils.ToUnixRelativePath(OutputFilename);

            // ---------------------------------
            //          Library Build
            // ---------------------------------
            if (CheckResult(result) && IsStaticLib())
            {
                await FileUtils.CopyDirectoryAdvAsync(AppInfo.BasePath, objsDir, new string[] { ".o" }, null, false, true);

                List<string> objFiles = await GetObjFiles();
                objFiles = CmdUtils.ToUnixRelativePaths(objFiles);

                BuildLibCmd libCmd =            new BuildLibCmd();
                libCmd.ObjectFiles =            objFiles;
                libCmd.LibOutputFilename =      result.OutputFilename;

                var libResult =                 await gnuGppWSL.BuildLibAsync(libCmd);
                libResult.LibOutputFilename =   libCmd.LibOutputFilename;
                result.OutputFilename =         libResult.LibOutputFilename;
            }

            return result;
        }

        private async Task<List<string>> GetObjFiles()
        {
            return await FileUtils.GetFilesAdvAsync(objsDir, new string[] { ".o" }, null, true, true, false);
        }

        /*private List<string> ToObjFiles(List<string> sources)
        {
            List<string> objs = new List<string>();

            foreach (string source in sources)
            {
                string dirPath = Path.GetDirectoryName(Path.GetFullPath(source));
                dirPath += "\\obj\\" + Path.GetFileNameWithoutExtension(source) + ".o";
                objs.Add(dirPath);
            }


            return objs;
        }*/

        private bool IsStaticLib()
        {
            return Setting.OutputType == OutputType.StaticLib;
        }

        private string ConvertOutputFilename(string fullFileName, OutputType type)
        {
            if (type == OutputType.Executable)
                return fullFileName;
            else if (type == OutputType.DynamicLib)
                return Path.ChangeExtension(fullFileName, ".so");
            else // if (type == OutputType.Static)
                return Path.ChangeExtension(fullFileName, ".a");
        }

    }
}
