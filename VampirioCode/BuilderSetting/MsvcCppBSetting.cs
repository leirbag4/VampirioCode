using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command.MSVC.Params;

namespace VampirioCode.BuilderSetting
{
    public class MsvcCppBSetting : BuilderSettingBase
    {
        // Copyables
        public List<CopyDirAction> CopyDirsPre { get; set; }
        public List<CopyDirAction> CopyDirsPost { get; set; }
        public List<CopyFileAction> CopyFilesPre { get; set; }
        public List<CopyFileAction> CopyFilesPost { get; set; }
        public List<VariableAction> PreprocessorMacros { get; set; }

        public List<string> PathValues { get; set; }

        public List<string> IncludeDirs { get; set; }
        public List<string> LibraryDirs { get; set; }
        public List<string> LibraryFiles { get; set; }

        public string InstallPackage { get; set; }

        public ExceptionHandlingModel ExceptionHanldingModel { get; set; }

        // Methods
        public void CopyDirPreAdd(string from, string to, bool overwrite = true)
        {
            if (CopyDirsPre == null) CopyDirsPre = new List<CopyDirAction>();
            CopyDirsPre.Add(new CopyDirAction() { From = from, To = to, Overwrite = overwrite});
        }

        public void CopyDirPostAdd(string from, string to, bool overwrite = true)
        {
            if (CopyDirsPost == null) CopyDirsPost = new List<CopyDirAction>();
            CopyDirsPost.Add(new CopyDirAction() { From = from, To = to, Overwrite = overwrite});
        }

        public void CopyFilePreAdd(string from, string to, bool overwrite = true)
        {
            if (CopyFilesPre == null) CopyFilesPre = new List<CopyFileAction>();
            CopyFilesPre.Add(new CopyFileAction() { From = from, To = to, Overwrite = overwrite});
        }

        public void CopyFilePostAdd(string from, string to, bool overwrite = true)
        {
            if (CopyFilesPost == null) CopyFilesPost = new List<CopyFileAction>();
            CopyFilesPost.Add(new CopyFileAction() { From = from, To = to, Overwrite = overwrite });
        }

        public void PreprocessorMacroAdd(string name, string value)
        {
            if (PreprocessorMacros == null) PreprocessorMacros = new List<VariableAction>();
            PreprocessorMacros.Add(new VariableAction() { Name = name, Value = value });
        }

        public void PathValueAdd(string path)
        {
            if (PathValues == null) PathValues = new List<string>();
            PathValues.Add(path);
        }

        public void IncludeDirAdd(string path)
        {
            if (IncludeDirs == null) IncludeDirs = new List<string>();
            IncludeDirs.Add(path);
        }

        public void LibraryDirAdd(string path)
        {
            if (LibraryDirs == null) LibraryDirs = new List<string>();
            LibraryDirs.Add(path);
        }

        public void LibraryFileAdd(string path)
        {
            if (LibraryFiles == null) LibraryFiles = new List<string>();
            LibraryFiles.Add(path);
        }


    }
}
