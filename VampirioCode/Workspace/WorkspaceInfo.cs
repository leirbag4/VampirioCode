using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VampirioCode.UI;

namespace VampirioCode.Workspace
{
    public class WorkspaceInfo
    {

        public string FilePath { get { return _filePath; } }
        public string WorkspaceFullFilePath { get { return _workspaceFullFilePath; } }
        public string RootDirFullPath { get { return _rootDirFullPath; } }
        public string VampDirPath { get { return _vampDirPath; } }

        private string _filePath;
        private string _workspaceFullFilePath;
        private string _rootDirFullPath;    // allProjects\[proj01]\_vamp\main\msvc ...
        private string _vampDirPath;       // allProjects\proj01\[_vamp]\main\msvc ...

        public WorkspaceInfo(string filePath, string workspaceFullFilePath, string rootDirFullPath)
        {
            _filePath =                 filePath;
            _workspaceFullFilePath =    workspaceFullFilePath;
            _rootDirFullPath =          rootDirFullPath;
            _vampDirPath =              _rootDirFullPath + "\\" + AppInfo.VampTempDir;
        }

        public bool IsMainFile(WorkspaceBase workspace)
        {
            string mainFile = GetMainFile(workspace);
            //XConsole.Alert("FilePath: " + FilePath + "\nmainFile: " + mainFile);
            
            return (FilePath == mainFile);
        }

        public string GetMainFile(WorkspaceBase workspace)
        { 
            return _rootDirFullPath + "\\" + workspace.MainFile;
        }

        public WorkspaceBase GetWorkspaceBase()
        {
            string json = File.ReadAllText(_workspaceFullFilePath);
            return JsonSerializer.Deserialize<WorkspaceBase>(json);
        }

        public T GetWorkspace<T>() where T : WorkspaceBase
        {
            string json = File.ReadAllText(_workspaceFullFilePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public override string ToString()
        {
            return "FilePath: " + FilePath + "\nWorkspaceFullFilePath: " + WorkspaceFullFilePath + "\nRootDirFullPath: " + RootDirFullPath + "\nVampDirPath: " + VampDirPath;
        }
    }
}
