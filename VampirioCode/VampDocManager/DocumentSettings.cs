using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VampirioCode.Builder;

namespace VampDocManager
{
    public class DocumentSettings
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DocumentType DocType { get; set; } = DocumentType.OTHER;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BuilderType BuilderType { get; set; } = BuilderType.None;

        public bool Custom { get; set; } = false;

        public override string ToString()
        {
            return "DocumentType: " + DocType + ", BuilderType: " + BuilderType + ", Custom: " + Custom;
        }
    }
}
