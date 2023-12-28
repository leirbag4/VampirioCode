using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.SaveData
{
    public class SavedDocument
    {
        public string FullFilePath { get; set; }    // e.g: C:\Files\Docs\myfile.cs
        public bool IsTemporal { get; set; }        // if file was created using 'file -> new' and was never saved, it will be mark as temporal

    }
}

