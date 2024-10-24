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
    public class PackageBuilder
    {

        public static void Create(  string author, string packageName, string description, Versioning versioning, BuilderType builderType, DocumentType language,
                                    string inputDataPath)
        { 
            PackageManifest manifest = new PackageManifest();
            manifest.Author =       author;
            manifest.PackageName =  packageName;
            manifest.Description =  description;
            manifest.Versioning =   versioning;
            manifest.BuilderType =  builderType;
            manifest.Language =     language;

        }

    }
}
