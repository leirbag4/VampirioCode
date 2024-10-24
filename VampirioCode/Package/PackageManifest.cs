using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder;
using VampirioCode.Environment;

namespace VampirioCode.Package
{
    public class PackageManifest
    {
        public string Author { get; set; } = "";
        public string PackageName { get; set; } = "";
        public string Description { get; set; } = "";
        public Versioning Versioning { get; set; } = new Versioning();
        public BuilderType BuilderType { get; set; } = BuilderType.None;
        public DocumentType Language { get; set; } = DocumentType.OTHER;
    }
}
