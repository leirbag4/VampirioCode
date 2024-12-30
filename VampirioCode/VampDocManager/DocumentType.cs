using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VampDocManager
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DocumentType
    {
        OTHER,
        CSHARP,
        HTML,
        JS,
        CPP,
        C,
        PHP,
        H,
        INC,
        TXT,
        JAVA
    }
}
