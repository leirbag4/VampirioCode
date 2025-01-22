using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder;
using VampirioCode.Workspace;

namespace VampDocManager
{
    public class OpenDocInfo
    {
        public WorkspaceInfo WorkspaceInfo { get; set; }
        public WorkspaceBase WorkspaceBase { get; set; }
        public BuilderType BuilderType { get; set; }
        public DocumentType DocumentType { get; set; }

        public OpenDocInfo(WorkspaceInfo workspaceInfo, WorkspaceBase workspaceBase, BuilderType builderType, DocumentType documentType)
        { 
            WorkspaceInfo = workspaceInfo;
            WorkspaceBase = workspaceBase;
            BuilderType =   builderType;
            DocumentType =  documentType;
        }
    }
}
