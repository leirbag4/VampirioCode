using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    public class Builder
    {
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

        public virtual void Prepare()
        { }

        public virtual async Task BuildAndRun()
        { }

        public virtual async Task Build()
        { }
    }
}
