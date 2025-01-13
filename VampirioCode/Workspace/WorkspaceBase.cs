using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using VampirioCode.IO;
using System.IO;
using VampDocManager;
using VampirioCode.Builder;
using VampirioCode.Builder.Custom;

namespace VampirioCode.Workspace
{
    public class WorkspaceBase
    {

        public string MainFile { get; set; }
        public DocumentType Language { get; set; }
        public DocumentType[] DocumentTypes { get; set; }
        public BuilderType DefaultBuilderType { get; set; }
        public List<WorkspaceProject> WorkspaceProjects { get; set; }
        
        protected void SetLanguage(DocumentType language)
        {
            Language = language;
        }

        protected void SetDocumentTypes(DocumentType type)
        {
            DocumentTypes = new[] { type }; 
        }

        protected void SetDocumentTypes(DocumentType type, DocumentType type2)
        {
            DocumentTypes = new[] { type, type2 };
        }

        protected void SetDocumentTypes(DocumentType type, DocumentType type2, DocumentType type3)
        {
            DocumentTypes = new[] { type, type2, type3 };
        }

        public bool IsTypeAllowed(DocumentType type)
        {
            foreach (var t in DocumentTypes)
            { 
                if(t == type)
                    return true;
            }

            return false;
        }

        public void RegisterProject(BuilderType builderType, BuilderKind builderKind)
        {
            if ((WorkspaceProjects == null) || (WorkspaceProjects.Count == 0))
            {
                WorkspaceProjects = new List<WorkspaceProject>();
                WorkspaceProjects.Add(new WorkspaceProject() { BuilderType = builderType, BuilderKind = builderKind });
            }
            else
            {
                // Check if already exists
                foreach (var workspaceProj in WorkspaceProjects)
                {
                    if (builderType == builderType)
                        return;
                }

                // Create one if doesn't exist
                WorkspaceProjects.Add(new WorkspaceProject() { BuilderType = builderType, BuilderKind = builderKind });

            }
        }

        public static ResultInfo Save<T>(T workspace, string path) where T : WorkspaceBase
        {
            try
            {
                string json = JsonSerializer.Serialize(workspace);
                File.WriteAllText(path, json);
                return ResultInfo.CreateOk();
            }
            catch (Exception e)
            {
                return ResultInfo.CreateError("Can't save Workspace File", e);
            }
        }

        public static T Load<T>(string path) where T : WorkspaceBase
        {
            try
            {
                string json = File.ReadAllText(path);
                T workspace = JsonSerializer.Deserialize<T>(json);
                return workspace;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /*public WorkspaceProject GetFirstOrDefaultWorkspaceProject()
        {
            for (int a = 0; a < WorkspaceProjects.Length; a++)
            {
                if (WorkspaceProjects[a] != null)
                    return WorkspaceProjects[a];
            }

            return null;
        }

        protected virtual WorkspaceProject[] LoadWorkspaceProject()
        {
            return null;
        }*/

        public override string ToString()
        {
            string str = "";

            str += "MainFile: " + MainFile + ", ";
            str += "Language: " + Language + " DocumentTypes [";

            foreach (var docType in DocumentTypes)
                str += docType + ", ";

            str = str.TrimEnd(' '); str = str.TrimEnd(',');

            str += "]";

            return str;
        }
    }
}
