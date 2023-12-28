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

namespace VampDocManager
{
    public class Document
    {
        public string FilePath { get; set; }
        public string FullFilePath { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public DocumentType DocType { get; set; }
        public bool IsTemporal { get; set; }        // if file was created using 'file -> new' and was never saved, it will be mark as temporal


        public static Document Load(string path)
        {
            Document doc = _Load(path);

            if (doc != null)
            {
                if (doc.FullFilePath.IndexOf(AppInfo.TemporalFilesPath) == 0)
                    doc.IsTemporal = true;
            }

            return doc;
        }

        public static Document NewTemporal()
        {
            string tempPath = AppInfo.TemporalFilesPath;

            // create temporal directory if not exists
            if(!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            // get next free number for temporal files. E.g: 'untitled 1' 'untitled 3' -> next will be ['untitled 2']
            string newFilePath = AppInfo.TemporalFilesPath + "untitled " + GetNextTemporalNumb() + ".txt";

            // try to create the new file
            try
            {
                File.WriteAllText(newFilePath, "");
            }
            catch (Exception e)
            {
                XConsole.ErrorAlert("Can't create new temporal file at '" + newFilePath + "'");
            }

            Document doc = _Load(newFilePath);
            
            if(doc != null)
                doc.IsTemporal = true;

            return doc;
        }

        private static Document _Load(string path)
        { 
            Document doc = new Document();

            try
            {
                doc.IsTemporal=     false;
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
                else                                doc.DocType = DocumentType.OTHER;
            }
            catch(Exception e)
            {
                return null;
            }

            return doc;
        }

        private static int GetNextTemporalNumb()
        {
            string[] files =    FileUtils.GetFileNamesAt(AppInfo.TemporalFilesPath);
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

        private void Read()
        {
            try
            {
                Text = File.ReadAllText(FullFilePath);
            }
            catch (Exception ee)
            {
                XConsole.ErrorAlert("Can't read the document at\n" + FullFilePath);
            }
        }

        public void Save()
        {
            try
            {
                File.WriteAllText(FullFilePath, Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Can't read the document at\n" + FullFilePath, "Can't read", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
