using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder;

namespace VampDocManager
{
    public class DocumentCopyStruct
    {
        bool customBuild;
        DocumentType docType;
        BuilderType builderType;

        public DocumentCopyStruct(Document doc)
        {
            CopyFrom(doc);
        }

        public void CopyFrom(Document doc)
        {
            this.customBuild = doc.CustomBuild;
            this.docType = doc.DocType;
            this.builderType = doc.BuilderType;
        }

        public void CopyTo(Document doc)
        {
            doc.CustomBuild = this.customBuild;
            doc.DocType = this.docType;
            doc.BuilderType = this.builderType;
        }
    }
}
