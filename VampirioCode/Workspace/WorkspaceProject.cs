using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder;
using VampirioCode.Builder.Custom;

namespace VampirioCode.Workspace
{
    public class WorkspaceProject
    {
        public BuilderType BuilderType { get; set; } = BuilderType.None;
        public BuilderKind BuilderKind { get; set; } = BuilderKind.None;
    }
}
