using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder.Utils;
using VampirioCode.Command;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode.Builder
{
    public class Builder
    {
        public string Name { get; set; } = "";
        public BuilderType Type = BuilderType.None;

        protected string TempDir { get; set; } = "";
        protected string BaseProjDir { get; set; } = "";
        protected string BuilderTypeDir { get; set; } = "";
        protected string ProjectDir { get; set; } = "";
        protected string ProgramFile { get; set; } = "";    // e.g: main.cpp  or  Program.cs
        public string OutputFilename { get; set; } = "";    // e.g: 'project.exe' or 'untitled 2.exe'

        protected string originalFullFilePath;  // e.g: C:\projects\capitan\main.cpp  or  .\vampirio\temp_files\untitled 2
        protected string originalBaseDirPath;   // e.g: C:\projects\capitan\          or  .\vampirio\temp_files\
        protected string originalBaseDirName;   // main.cpp                        or  untitled 2
        protected string originalFileName;      // main.cpp                        or  untitled 2
        protected string projectName;           // main                            or  untitled 2
        protected string code = "";

        public void Setup(string originalFullFilePath, string code)
        {
            //XConsole.Alert("originalFullFilePath: " + originalFullFilePath);
            this.originalFullFilePath = originalFullFilePath.Trim();
            this.originalFileName =     BuilderUtils.GetFileNameOnly(originalFullFilePath);
            this.projectName =          BuilderUtils.GetProjName(originalFullFilePath);
            this.code = code;

            //XConsole.Alert("originalFileName: " + originalFileName);
            //XConsole.Alert("projectName: " + projectName);

            if (originalFullFilePath != "")
            {
                originalBaseDirPath = Path.GetDirectoryName(originalFullFilePath);
                originalBaseDirName = Path.GetFileName(originalBaseDirPath);
                //originalBaseDirPath += "\\";

                //XConsole.Alert("O: originalBaseDirPath: " + originalBaseDirPath);
                //XConsole.Alert("O: originalBaseDirName: " + originalBaseDirName);
            }
            else
            {
                originalBaseDirPath = "";
                originalBaseDirName = "";
            }
        }

        public string GetOriginalFullFilePath() { return originalFullFilePath; }
        public string GetOriginalBaseDirPath() { return originalBaseDirPath; }
        public string GetOriginalBaseDirName() { return originalBaseDirName; }
        public string GetProjectName() { return projectName; }
        public string GetTempDir() { return TempDir; }
        public string GetBaseProjDir() { return BaseProjDir; }
        public string GetProjectDir() { return ProjectDir; }
        public string GetProgramFile() { return ProgramFile; }
        public string GetOutputFilename() { return OutputFilename; }

        protected bool CheckResult(BaseResult result)
        {
            if (result.IsOk)
                XConsole.FooterInfo("build complete");
            else //if(result.Error)
                XConsole.FooterInfo("build with errors");

            return result.IsOk;
        }

        protected virtual void CreateProjectStructure()
        {
            if (!Directory.Exists(TempDir))
                Directory.CreateDirectory(TempDir);

            if (Directory.Exists(ProjectDir))
                Directory.Delete(ProjectDir, true);

            Directory.CreateDirectory(ProjectDir);
        }

        protected string _quotes(string str)
        {
            return '"' + str + '"';
        }

        protected string _fixNameSpaces(string name)
        {
            return name.Replace(" ", "_");
        }

        //
        // FIX the last bar that escapes a quote at the end.
        // Input  -> "C:\tests\"  [BAD] to
        // Output -> "C:\tests\\" [OK]
        //
        // If you don't fix it, this could happened:
        //   -> [cmd.exe "C:\tests\" "app"]  will be see as
        //      [cmd.exe "C:\tests\ "app" ]
        //
        protected string _fixLastEscapeBar(string str)
        {
            if (str.EndsWith("\\") && !str.EndsWith("\\\\"))
                return (str + "\\");

            return str;
        }

        public virtual void Prepare()
        { }

        public async Task BuildAndRun()
        {
            XConsole.FooterInfo("building...");
            OnBuildAndRun();
        }

        protected virtual async Task OnBuildAndRun()
        { }

        public async Task Build()
        {
            XConsole.FooterInfo("building...");
            OnBuild();
        }

        protected virtual async Task OnBuild()
        { }

        public void DeleteBuild()
        {
            if (Directory.Exists(BaseProjDir))
            {
                try
                {
                    Directory.Delete(BaseProjDir, true);
                    XConsole.LogInfo("Build for '" + BaseProjDir + "' deleted [done]");
                }
                catch (Exception e)
                {
                    XConsole.LogError("Can't delete build for'" + BaseProjDir + "'");
                }
            }
            
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Type: {Type}\n" +
                   $"TempDir: {TempDir}\n" +
                   $"BaseProjDir: {BaseProjDir}\n" +
                   $"ProjectDir: {ProjectDir}\n" +
                   $"ProgramFile: {ProgramFile}\n" +
                   $"OutputFilename: {OutputFilename}\n" +
                   $"originalFullFilePath: {originalFullFilePath}\n" +
                   $"originalBaseDir: {originalBaseDirPath}\n" +
                   $"projectName: {projectName}";
        }

    }
}
