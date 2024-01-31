using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;

namespace VampirioCode.SaveData
{
    public class SavedDocument
    {
        public string FullFilePath { get; set; }        // e.g: C:\Files\Docs\myfile.cs
        public bool IsTemporary { get; set; }           // if file was created using 'file -> new' and was never saved, it will be mark as temporary

        public DocumentSettings DocumentSettings { get; set; } // extra settings for document. E.g: use change syntax/language from c++ to C# on a document without extension (a temporary file)
    }
}

