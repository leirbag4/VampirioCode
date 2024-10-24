using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder;

namespace VampirioCode.Package
{
    public class PackageInfo
    {
        public BuilderType BuilderType { get; set; } = BuilderType.None;
        public DocumentType DocumentType { get; set; } = DocumentType.OTHER;
        //public BuilderCategory BuilderCategory { get { return BuilderCategory.Custom; } }
        public string Path { get { return _GetPath(this.DocumentType, BuilderType); } }

        public static void Initialize()
        {
            _Create(DocumentType.CPP, BuilderType.CustomMsvcCpp);
            _Create(DocumentType.CPP, BuilderType.CustomGnuGppWSLCpp);
        }

        private static PackageInfo _Create(DocumentType documentType, BuilderType builderType)
        {
            PackageInfo package =   new PackageInfo();
            package.DocumentType =  documentType;
            package.BuilderType =   builderType;

            return package;
        }

        private static string _GetPath(DocumentType documentType, BuilderType builderType)
        {
            DocumentTypeInfo docType = DocumentTypeInfo.Get(documentType);
            return (AppInfo.PackagesPath + docType.CodeName + "\\");
        }
    }
}
