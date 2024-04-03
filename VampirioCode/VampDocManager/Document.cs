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
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public DocumentType DocType { get; set; }
        public BuilderType BuilderType { get; set; }
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
            string newFilePath = AppInfo.TemporaryFilesPath + "untitled " + GetNextTemporaryNumb();// + ".txt";

            // try to create the new file
            try
            {
                File.WriteAllText(newFilePath, "");
            }
            catch (Exception e)
            {
                XConsole.ErrorAlert("Can't create new temporary file at '" + newFilePath + "'");
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
                File.Delete(document.FullFilePath);
                return true;
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

                     if (doc.Extension == ".cs")    doc.DocType = DocumentType.CSHARP;
                else if (doc.Extension == ".html")  doc.DocType = DocumentType.HTML;
                else if (doc.Extension == ".js")    doc.DocType = DocumentType.JS;
                else if (doc.Extension == ".cpp")   doc.DocType = DocumentType.CPP;
                else if (doc.Extension == ".c")     doc.DocType = DocumentType.C;
                else if (doc.Extension == ".h")     doc.DocType = DocumentType.H;
                else if (doc.Extension == ".inc")   doc.DocType = DocumentType.INC;
                else if (doc.Extension == ".php")   doc.DocType = DocumentType.PHP;
                else if (doc.Extension == ".txt")   doc.DocType = DocumentType.TXT;
                else if (doc.Extension == ".java")  doc.DocType = DocumentType.JAVA;
                else                                doc.DocType = DocumentType.OTHER;

                doc.BuilderType = Builders.GetDefaultTypeFor(doc.DocType);
            }
            catch(Exception e)
            {
                return null;
            }

            return doc;
        }

        private static int GetNextTemporaryNumb()
        {
            string[] files =    FileUtils.GetFileNamesAt(AppInfo.TemporaryFilesPath);
            int[] numbers =     new int[files.Length];
            int currNumb =      0;
            int i;

            if (files.Length == 0)
                return 1;

            for(int a = 0; a < files.Length; a++)
            {
                numbers[a] = int.Parse(Path.GetFileNameWithoutExtension(files[a]).Split(" ")[1]);
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
