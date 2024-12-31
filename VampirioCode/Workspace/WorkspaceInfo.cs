using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VampirioCode.UI;
using VampirioCode.Workspace.cpp;

namespace VampirioCode.Workspace
{
    public class WorkspaceInfo
    {

        public string FilePath { get { return _filePath; } }
        public string WorkspaceFullFilePath { get { return _workspaceFullFilePath; } }
        public string RootDirFullPath { get { return _rootDirFullPath; } }
        public string VampDirPath { get { return _vampDirPath; } }
        public string MainDirName { get { return Path.GetFileNameWithoutExtension(_filePath); } }
        public string MainDirFullPath { get { return Path.Combine(VampDirPath, MainDirName); } }
        

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

        public CppWorkspace GetCppWorkspace()
        { 
            return GetWorkspace<CppWorkspace>();
        }

        public T GetWorkspace<T>() where T : WorkspaceBase
        {
            string json = File.ReadAllText(_workspaceFullFilePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        protected void SaveWorkspace<T>(T workspace) where T : WorkspaceBase
        {
            string json = JsonSerializer.Serialize<T>(workspace);
            File.WriteAllText(_workspaceFullFilePath, json);
        }

        public void ReplaceMainFile(string newFileName)
        {
            string json = File.ReadAllText(_workspaceFullFilePath);

            string find =       "\"MainFile\":\"";
            int index =         json.IndexOf(find) + find.Length;
            int length =        json.IndexOf("\"", index) - index;
            string str0 =       json.Substring(0, index);
            string str1 =       json.Substring(index + length);
            string newJson =     str0 + newFileName + str1;

            if (index == -1)
                throw new Exception("MainFile could be changed!");

            File.WriteAllText(_workspaceFullFilePath, newJson);
        }

        public override string ToString()
        {
            return "FilePath: " + FilePath + "\nWorkspaceFullFilePath: " + WorkspaceFullFilePath + "\nRootDirFullPath: " + RootDirFullPath + "\nVampDirPath: " + VampDirPath + "\nMainDirName: " + MainDirName + "\nMainDirFullPath: " + MainDirFullPath;
        }
    }
}
