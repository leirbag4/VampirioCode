using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Environment;

namespace VampirioCode.BuilderSetting
{
    public class BuilderSettingBase
    {
        public string TemplateAuthor { get; set; } = "";
        public string TemplateName { get; set; } = "";
        public string TemplateDescription { get; set; } = "";
        public Versioning MyProperty { get; set; } = new Versioning();
        public BuilderType TemplateBuilderType { get; set; } = BuilderType.None;
        public DocumentType TemplateDocumentType { get; set; } = DocumentType.OTHER;
        public string InstallPackage { get; set; } = "";
        public List<string> InstallPackages { get; set; } = new List<string>();

    }
}
