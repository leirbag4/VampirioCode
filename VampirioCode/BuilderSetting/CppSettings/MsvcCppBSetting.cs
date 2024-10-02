using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command.MSVC.Params;

namespace VampirioCode.BuilderSetting.CppSettings
{
    public class MsvcCppBSetting : BuilderSettingBase
    {
        // Copyables
        //public List<CopyDirAction> CopyDirsPre { get; set; }
        public List<CopyAction> CopyDirsPost { get; set; } = new List<CopyAction>();
        //public List<CopyFileAction> CopyFilesPre { get; set; }
        public List<CopyAction> CopyFilesPost { get; set; } = new List<CopyAction>();
        public List<VariableAction> PreprocessorMacros { get; set; } = new List<VariableAction>();

        public List<string> PathValues { get; set; } = new List<string>();

        public List<string> IncludeDirs { get; set; } = new List<string>();
        public List<string> LibraryDirs { get; set; } = new List<string>();
        public List<string> LibraryFiles { get; set; } = new List<string>();

        public string InstallPackage { get; set; } = "";

        public StandardVersion StandardVersion { get; set; } = StandardVersion.None;
        public ExceptionHandlingModel ExceptionHanldingModel { get; set; } = ExceptionHandlingModel.None;

        // Methods
        /*public void CopyDirPreAdd(string from, string to, bool overwrite = true)
        {
            if (CopyDirsPre == null) CopyDirsPre = new List<CopyDirAction>();
            CopyDirsPre.Add(new CopyDirAction() { From = from, To = to, Overwrite = overwrite});
        }*/

        public void CopyDirPostAdd(string from, string to, bool overwrite = true)
        {
            if (CopyDirsPost == null) CopyDirsPost = new List<CopyAction>();
            CopyDirsPost.Add(new CopyAction() { From = from, To = to, Overwrite = overwrite });
        }

        /*public void CopyFilePreAdd(string from, string to, bool overwrite = true)
        {
            if (CopyFilesPre == null) CopyFilesPre = new List<CopyFileAction>();
            CopyFilesPre.Add(new CopyFileAction() { From = from, To = to, Overwrite = overwrite});
        }*/

        public void CopyFilePostAdd(string from, string to, bool overwrite = true)
        {
            if (CopyFilesPost == null) CopyFilesPost = new List<CopyAction>();
            CopyFilesPost.Add(new CopyAction() { From = from, To = to, Overwrite = overwrite });
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
