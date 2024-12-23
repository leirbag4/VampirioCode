using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;

namespace VampirioCode.Workspace.cpp
{
    public class CppWorkspace : WorkspaceBase
    {
        /*public WorkspaceProject MsvcProject { get; }
        public WorkspaceProject GnuGppProject { get; }
        public WorkspaceProject ClangProject { get; }
        public WorkspaceProject EmscriptenProject { get; }*/

        public CppWorkspace()
        {
            SetLanguage(DocumentType.CPP);
            SetDocumentTypes(DocumentType.CPP, DocumentType.H);
            //WorkspaceProjects = new WorkspaceProject[] { MsvcProject, GnuGppProject, ClangProject, EmscriptenProject };
        }

        public override string ToString()
        {
            string str = base.ToString() + "\n";

            /*if(MsvcProject != null)         str += "MsvcProject: " +        MsvcProject.ToString() +    "\n";
            if(GnuGppProject != null)       str += "GnuGppProject: " +      GnuGppProject.ToString() +  "\n";
            if(ClangProject != null)        str += "ClangProject: " +       ClangProject.ToString() +   "\n";
            if(EmscriptenProject != null)   str += "EmscriptenProject: " +  EmscriptenProject.ToString();
            */
            return str;
        }
    }
}
