using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace VampDocManager
{
    public class Document
    {
        public string FilePath { get; set; }
        public string FullFilePath { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public DocumentType DocType { get; set; }

        public Document(string path)
        {
            FilePath =      path.Trim();
            FullFilePath =  Path.GetFullPath(path);
            Filename =      Path.GetFileName(path);
            Extension =     Path.GetExtension(Filename).ToLower();
            Text = "";

                 if (Extension == ".cs")    DocType = DocumentType.CSHARP;
            else if (Extension == ".html")  DocType = DocumentType.HTML;
            else if (Extension == ".js")    DocType = DocumentType.JS;
            else if (Extension == ".cpp")   DocType = DocumentType.CPP;
            else if (Extension == ".c")     DocType = DocumentType.C;
            else if (Extension == ".h")     DocType = DocumentType.H;
            else if (Extension == ".inc")   DocType = DocumentType.INC;
            else                            DocType = DocumentType.OTHER;

            Read();
        }

        private void Read()
        {
            try
            {
                Text = File.ReadAllText(FullFilePath);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Can't read the document at\n" + FullFilePath, "Can't read", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
