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
