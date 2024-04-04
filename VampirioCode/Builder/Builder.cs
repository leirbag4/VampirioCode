using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class Builder
    {
        public string Name { get; set; } = "";
        public BuilderType Type = BuilderType.None;

        protected string TempDir { get; set; } = "";
        protected string ProjectDir { get; set; } = "";
        protected string ProgramFile { get; set; } = "";    // e.g: main.cpp  or  Program.cs
        public string OutputFilename { get; set; } = "";    // e.g: 'project.exe' or 'untitled 2.exe'

        protected string projectName;
        protected string code = "";

        public void Setup(string projectName, string code)
        {
            this.projectName = projectName;
            this.code = code;
        }

        protected void CheckResult(BaseResult result)
        {
            if (result.IsOk)
                XConsole.FooterInfo("build complete");
            else //if(result.Error)
                XConsole.FooterInfo("build with errors");
        }

        protected void CreateProjectStructure()
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
    }
}
