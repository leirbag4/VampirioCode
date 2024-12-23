using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder;

namespace VampirioCode.Workspace
{
    public class WorkspaceProject
    {
        public string MainFile { get; set; } = "";
        public BuilderType BuilderType { get; set; } = BuilderType.None;

        public override string ToString()
        {
            return "MainFile: " + MainFile + ", BuilderType: " + BuilderType;
        }
    }
}
