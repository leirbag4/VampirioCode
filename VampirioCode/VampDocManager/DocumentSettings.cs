using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder;

namespace VampDocManager
{
    public class DocumentSettings
    {
        public DocumentType DocType { get; set; } = DocumentType.OTHER;

        public BuilderType BuilderType { get; set; } = BuilderType.None;

        public bool Custom { get; set; } = false;

    }
}
