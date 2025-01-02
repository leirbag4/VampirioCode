using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VampirioCode;
using VampirioCode.Utils;
using VampirioCode.UI;
using VampirioCode.SaveData;
using ScintillaNET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using VampirioCode.Builder;
using VampirioCode.IO;
using VampirioCode.Builder.Utils;
using VampirioCode.Workspace;
using VampirioCode.Workspace.cpp;

namespace VampDocManager
{
    public class Document
    {

        public delegate void SavedEvent();
        public delegate void ModifiedEvent();

        public event SavedEvent OnSaved;
        public event ModifiedEvent OnModified;

        public string FilePath { get; set; }
        public string FullFilePath { get; set; }
        public string FullDirPath { get { return Path.GetDirectoryName(FullFilePath); } }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public DocumentType DocType { get; set; }
        public BuilderType BuilderType { get; set; }
        public bool CustomBuild { get; set; }
        public bool IsTemporary { get; set; }        // if file was created using 'file -> new' and was never saved, it will be mark as temporary
        public bool Modified { get { return _modified; } set { _modified = value; if (OnModified != null) OnModified(); } }

        protected bool _modified = false;

        public static Document Load(string path)
        {
            Document doc = _Load(path);

            if (doc != null)
            {
                if (doc.FullFilePath.IndexOf(AppInfo.TemporaryFilesPath) == 0)
                    doc.IsTemporary = true;
            }
            return doc;
        }

        public static Document NewTemporary()
        {
            string tempPath = AppInfo.TemporaryFilesPath;

            // create temporary directory if not exists
            if(!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            // get next free number for temporary files. E.g: 'untitled 1' 'untitled 3' -> next will be ['untitled 2']
            string fileNameOnly =   "untitled " + GetNextTemporaryNumb();
            // create a new directory for the temp file called equaly 'untitled 1\untitled 1', 'untitled 2\untitled 2'
            string dirForFile =     fileNameOnly;
            // path up to new directory for the file. e.g: 'c:\\programs\\vampirio\\temp_files\\untitled 1'
            string newDirPath = AppInfo.TemporaryFilesPath + dirForFile;

            // full path for new temp file like: 'c:\\programs\\vampirio\\temp_files\\untitled 1\\untitled 1'
            string newFilePath = newDirPath + "\\" + fileNameOnly;

            // try to create the new file
            try
            {
                if(!Directory.Exists(newDirPath))
                    Directory.CreateDirectory(newDirPath);

                File.WriteAllText(newFilePath, "");
            }
            catch (Exception e)
            {
                XConsole.ErrorAlert("Can't create new temporary file at '" + newFilePath + "'", e);
            }

            Document doc = _Load(newFilePath);
            
            if(doc != null)
                doc.IsTemporary = true;

            return doc;
        }

        public static bool Delete(Document document)
        {
            try
            {
                // Is inside 'temp_files' folder?
                // In this case there is a folder for the file called equaly
                // e.g: 'untitled 2\untitled 2'. We just need to delete the folder
                if (document.IsTemporary)
                {
                    //XConsole.Alert("dir to delete:\n\n" + document.FullDirPath);
                    Directory.Delete(document.FullDirPath, true);
                    return true;
                }
                else
                {
                    throw new Exception("Temporary files and dirs are only allowed to be deleted!");
                }

            }
            catch (Exception e)
            {
                MsgBox.Error(@"Can't delete file '" + document.FullFilePath + "'", e);
                return false;
            }
        }

        private static Document _Load(string path)
        { 
            Document doc = new Document();

            try
            {
                doc.IsTemporary=     false;
                doc.FilePath =      path.Trim();
                doc.FullFilePath =  Path.GetFullPath(path);
                doc.FileName =      Path.GetFileName(path);
                doc.Extension =     Path.GetExtension(doc.FileName).ToLower();
                doc.Read();

                // Get the DocumentType for the extension
                // E.g: extention =  '.cpp'              or      '.h' with dot
                //      returns      DocumentType.CPP    or      DocumentType.H
                doc.DocType =       ExtensionToDocType(doc.Extension);

                doc.BuilderType = Builders.GetDefaultTypeFor(doc.DocType);
            }
            catch(Exception e)
            {
                return null;
            }

            return doc;
        }

        // extention =  '.cpp'              or      '.h' with dot
        // returns      DocumentType.CPP    or      DocumentType.H
        public static DocumentType ExtensionToDocType(string extension)
        { 
                 if (extension == ".cs")    return DocumentType.CSHARP;
            else if (extension == ".html")  return DocumentType.HTML;
            else if (extension == ".js")    return DocumentType.JS;
            else if (extension == ".cpp")   return DocumentType.CPP;
            else if (extension == ".c")     return DocumentType.C;
            else if (extension == ".h")     return DocumentType.H;
            else if (extension == ".inc")   return DocumentType.INC;
            else if (extension == ".php")   return DocumentType.PHP;
            else if (extension == ".txt")   return DocumentType.TXT;
            else if (extension == ".java")  return DocumentType.JAVA;
            else                            return DocumentType.OTHER;
        }

        public static DocumentType GetDocType(string fullFilePath)
        { 
            return ExtensionToDocType(Path.GetExtension(fullFilePath).ToLower());
        }

        private static int GetNextTemporaryNumb()
        {
            string[] dirs =    FileUtils.GetDirectoryNamesAt(AppInfo.TemporaryFilesPath);//FileUtils.GetFileNamesAt(AppInfo.TemporaryFilesPath);
            int[] numbers =     new int[dirs.Length];
            int currNumb =      0;
            int i;

            if (dirs.Length == 0)
                return 1;

            for(int a = 0; a < dirs.Length; a++)
            {
                numbers[a] = int.Parse(Path.GetFileNameWithoutExtension(dirs[a]).Split(" ")[1]);
            }

            Array.Sort(numbers);


            for(int a = 0; a < numbers.Length; a++)
            {
                i = a + 1;
                currNumb = numbers[a];

                if(i < currNumb)
                    return i;

                i++;
            }

            return ++currNumb;
        }

        public void CopyFrom(Document newDocument)
        {
            PropertyInfo[] properties = typeof(Document).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(newDocument));
            }
        }



        public ResultInfo Move(string newFilePath)
        {
            string code;

            if (this.IsTemporary)
            {
                try
                {
                    var copyStruct = new DocumentCopyStruct(this);

                    code = this.Text;
                    File.Move(this.FullFilePath, newFilePath, true);
                    //Config.ReplaceLastOpenDocsPath(this.FullFilePath, newFilePath);
                    this.CopyFrom(Document.Load(newFilePath));
                    copyStruct.CopyTo(this);
                    this.Text = code;
                    this.Save();
                    return ResultInfo.CreateOk();
                }
                catch (Exception e)
                {
                    return ResultInfo.CreateError("Can't save temporary file: '" + this.FullFilePath + "' to '" + newFilePath + "'", e);
                }
            }
            else
            {
                try
                {
                    var copyStruct = new DocumentCopyStruct(this);

                    File.WriteAllText(newFilePath, "");
                    code = this.Text;
                    File.Delete(FullFilePath);
                    //Config.ReplaceLastOpenDocsPath(this.FullFilePath, newFilePath);
                    //File.Delete(CurrDocument.FullFilePath);
                    this.CopyFrom(Document.Load(newFilePath));
                    copyStruct.CopyTo(this);
                    this.Text = code;
                    this.Save();
                    return ResultInfo.CreateOk();
                }
                catch (Exception e)
                {
                    return ResultInfo.CreateError("Can't save file: '" + this.FullFilePath + "' to '" + newFilePath + "'", e);
                }
            }

        }

        // 'newFileName' = is like 'tester.cpp' and not full path
        public ResultInfo Rename(string newFileName, bool updateMainDirName = false)
        {
            string newFullFile = Path.Combine(FullDirPath, newFileName);

            if (newFullFile.Trim() == FullFilePath.Trim())
            {
                return ResultInfo.CreateError("Can't rename the file to its own name");
            }

            WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(FullFilePath);

            if (workspaceInfo != null)
            {
                XConsole.Println("info: " + workspaceInfo.ToString());

                string mainFullDirPath = workspaceInfo.MainDirFullPath;

                WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
                XConsole.Println("wb: " + workspace.ToString());

                XConsole.PrintWarning("RENAME FROM: " + FullFilePath);
                XConsole.PrintWarning("RENAME TO:   " + newFullFile);

                if (workspaceInfo.IsMainFile(workspace))
                {
                    XConsole.PrintError("IS MAIN FILE: " + FullFilePath);
                    workspaceInfo.ReplaceMainFile(newFileName);
                }

                if (updateMainDirName)
                {
                    string parentDirectory =    Path.GetDirectoryName(mainFullDirPath);
                    string newMainDirFullPath = Path.Combine(parentDirectory, Path.GetFileNameWithoutExtension(newFileName));

                    XConsole.Println("RENAME from: " + mainFullDirPath);
                    XConsole.Println("RENAME to:   " + newMainDirFullPath);
                    Directory.Move(mainFullDirPath, newMainDirFullPath);


                    //XConsole.Alert("IS: " + newMainDirFullPath);
                }
            }
            else
            {
                XConsole.Println("Has not a workspace. Just rename.");
            }

            Move(newFullFile);

            return ResultInfo.CreateOk();
        }

        private bool Read()
        {
            try
            {
                // IMPORTANT: to avoid Bugs, any line ending different to \n will be replaced to \n.
                //            So windows line breaks like \r\n are converted to \n
                //            And when saving the file, they will be saved using Environment.NewLine
                Text = File.ReadAllText(FullFilePath).ReplaceLineEndings("\n");
                return true;
            }
            catch (Exception ee)
            {
                XConsole.ErrorAlert("Can't read the document at\n" + FullFilePath);
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                // IMPORTANT: when opening a file, line endings like \r\n will be converted to \n
                //            So if user save the file, by now they will be converted to the line ending
                //            of their environment.
                //      TODO: determine at loading the line ending of the file and return them for the save state
                File.WriteAllText(FullFilePath, Text.ReplaceLineEndings(Environment.NewLine));
                Modified = false;

                if(OnSaved != null)
                    OnSaved();
                return true;
            }
            catch (Exception ee)
            {
                MsgBox.Error("Can't read the document at\n" + FullFilePath);
                return false;
            }
        }

        
    }
}
