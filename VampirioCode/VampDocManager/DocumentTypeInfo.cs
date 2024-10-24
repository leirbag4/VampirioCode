using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;

namespace VampDocManager
{
    public class DocumentTypeInfo
    {

        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
        public string MinName { get; set; }
        public string FullName { get; set; }
        public string CodeName { get; set; } // IMPORTANT: don't change it!!!

        private static Dictionary<DocumentType, DocumentTypeInfo> docTypeInfos = new Dictionary<DocumentType, DocumentTypeInfo>();

        public static void Initialize()
        {                                                                               // IMPORTANT: don't change 
                                                                                        // code names NEVER!
                                                                                        // They are used for folders and tags
            _Create(DocumentType.OTHER, "other",        "other",    "other",            "other");
            _Create(DocumentType.CSHARP,"C#",           "c#",       "C# File",          "csharp");
            _Create(DocumentType.HTML,  "HTML",         "Html",     "HTML File",        "html");
            _Create(DocumentType.JS,    "Javascript",   "JS",       "Javascript File",  "js");
            _Create(DocumentType.C,     "C",            "c",        "C File",           "c");
            _Create(DocumentType.PHP,   "PHP",          "Php",      "PHP File",         "php");
            _Create(DocumentType.H,     "H",            "h",        "Header File",      "h");
            _Create(DocumentType.INC,   "INC",          "inc",      "Include File",     "inc");
            _Create(DocumentType.TXT,   "TXT",          "txt",      "Txt File",         "txt");
            _Create(DocumentType.JAVA,  "JAVA",         "java",     "Java File",        "java");
        }

        private static void _Create(DocumentType docType, string name, string minName, string fullName, string codeName)
        {
            DocumentTypeInfo docInfo = new DocumentTypeInfo();
            docInfo.DocumentType =  docType;
            docInfo.Name =          name;
            docInfo.MinName =       minName;
            docInfo.FullName =      fullName;
            docInfo.CodeName =      codeName;

            docTypeInfos.Add(docType, docInfo);
        }

        public static DocumentTypeInfo Get(DocumentType docType)
        {
            return docTypeInfos[docType];
        }
    }
}
